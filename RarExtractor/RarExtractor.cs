using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;

namespace RarExtractor
{
    public partial class RarExtractor : Form
    {
        private const string RarFileExtension = ".rar";
        private const string ConfigDefault = "Config_default.ini";
        private const string Painel01NfeDefault = "PAINEL01_NFE_default.INI";
        private string LabelProgressoText { get; set; } = "";

        public RarExtractor()
        {
            InitializeComponent();
            ConfigureForm();
        }

        private void ConfigureForm()
        {
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            lblProgresso.Text = LabelProgressoText;
            EnableControls(false, true, false);
        }

        private void EnableControls(bool isEnabled, bool isEnabledDirectories = true, bool isEnabledProcess = true)
        {
            chk_deleteCompactados.Enabled = isEnabled;
            chk_rename_default.Enabled = isEnabled;

            obtemDiretorios.Enabled = isEnabledDirectories;
            processa.Enabled = isEnabledProcess;
        }

        private void GetDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listagemDiretorios.Items.Add(folderBrowserDialog1.SelectedPath);
                EnableControls(true);
            }
        }

        private void DirectoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listagemDiretorios.SelectedItem != null)
            {
                listagemDiretorios.Items.Remove(listagemDiretorios.SelectedItem);
            }

            EnableControls(listagemDiretorios.Items.Count > 0, true, false);
        }

        private async void Process_Click(object sender, EventArgs e)
        {
            if (listagemDiretorios.Items.Count == 0)
            {
                ShowErrorMessage("Selecione ao menos um diretório para continuar!");
                return;
            }

            await ExtractFilesAsync();


            ShowSuccessMessage("Arquivos descompactados com sucesso!");
            progressBar1.Value = 0;
            LabelProgressoText = "";
            lblProgresso.Text = LabelProgressoText;
            EnableControls(true);
        }

        private async Task ExtractFilesAsync()
        {
            EnableControls(false, false, false);
            currentDirectory.ResetText();

            List<string> directories = listagemDiretorios.Items.Cast<string>().ToList();
            foreach (string directory in directories)
            {
                string[] subDirectories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);

                progressBar1.Maximum = subDirectories.Count();
                progressBar1.Value = 0;
                foreach (string subDirectory in subDirectories)
                {
                    progressBar1.Value += 1;
                    LabelProgressoText = $"Extraindo {progressBar1.Value} de {progressBar1.Maximum} subdiretórios. $msg";

                    await ExtractFilesFromDirectory(subDirectory);
                }

                // Atualiza a interface do usuário após a extração de cada diretório
                UpdateUI();
            }
        }

        private async Task ExtractFilesFromDirectory(string directory)
        {
            IEnumerable<string> rarFiles = GetRarFilesInDirectory(directory);
            if (rarFiles.Count() == 0)
            {
                currentDirectory.AppendText($"Não há arquivos {RarFileExtension} para extrair no diretório: '{Path.GetFileName(directory)}'{Environment.NewLine}");
                return;
            }

            var extractedFilesDictionary = new Dictionary<string, DateTime>();
            for (int index = 0; index < rarFiles.Count(); index++)
            {
                string rarFile = rarFiles.ElementAt(index);
                string progressText = LabelProgressoText.Replace("$msg", string.Format("Processando arquivo {0} de {1}.", index + 1, rarFiles.Count()));
                lblProgresso.Text = progressText;

                currentDirectory.AppendText($"{Path.GetFileName(rarFile)} => OK {Environment.NewLine}");

                await Task.Run(() => ExtractEntriesFromRarFile(rarFile, directory, extractedFilesDictionary));
                await Task.Run(() => DeleteRarFileIfRequired(rarFile, chk_deleteCompactados.Checked));
                await Task.Run(() => RenameFilesIfRequired(directory, rarFile));

                UpdateUI();
            }
        }

        private IEnumerable<string> GetRarFilesInDirectory(string directory)
        {
            return Directory.GetFiles(directory)
                .Where(file => file.EndsWith(RarFileExtension));
        }

        private void ExtractEntriesFromRarFile(string rarFile, string directory, Dictionary<string, DateTime> extractedFilesDictionary)
        {
            using (var archive = RarArchive.Open(rarFile))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    if (!extractedFilesDictionary.ContainsKey(entry.Key))
                    {
                        extractedFilesDictionary.Add(entry.Key, entry.LastModifiedTime.GetValueOrDefault());
                        entry.WriteToDirectory(directory, GetExtractionOptions());
                    }
                    else
                    {
                        var existingEntryLastModifiedTime = extractedFilesDictionary[entry.Key];

                        if (entry.LastModifiedTime > existingEntryLastModifiedTime)
                        {
                            extractedFilesDictionary[entry.Key] = entry.LastModifiedTime.GetValueOrDefault();
                            entry.WriteToDirectory(directory, GetExtractionOptions());
                        }
                    }
                }
            }
        }

        private ExtractionOptions GetExtractionOptions()
        {
            return new ExtractionOptions
            {
                ExtractFullPath = true,
                PreserveFileTime = true,
                Overwrite = true
            };
        }

        private void DeleteRarFileIfRequired(string rarFile, bool deleteCompactadosChecked)
        {
            if (deleteCompactadosChecked)
            {
                File.Delete(rarFile);
            }
        }

        private void RenameFilesIfRequired(string directory, string rarFile)
        {
            if (chk_rename_default.Checked && directory.Contains("Control"))
            {
                string[] files = Directory.GetFiles(directory);

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);

                    if (fileName == ConfigDefault || fileName == Painel01NfeDefault)
                    {
                        string newFileName = fileName.Replace("_default", "");
                        string newFilePath = Path.Combine(directory, newFileName);

                        RenameFile(file, newFilePath);
                    }
                }
            }
        }

        private void RenameFile(string originalName, string newName)
        {
            File.Move(originalName, newName);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateUI()
        {
            System.Windows.Forms.Application.DoEvents();
            Refresh();
        }
    }
}
