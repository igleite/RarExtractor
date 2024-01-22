using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

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

            listagemDiretorios.Enabled = isEnabledDirectories;
            obtemDiretorios.Enabled = isEnabledDirectories;
            processa.Enabled = isEnabledProcess;
        }

        private void GetDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                List<string> directories = listagemDiretorios.Items.Cast<string>().ToList();
                var selectedDirectories = directories.Where(d => d == folderBrowserDialog1.SelectedPath).ToList();
                if (selectedDirectories.Count > 0)
                {
                    ShowErrorMessage("O diretório selecionado já foi adicionado!");
                    return;
                }

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

            bool enable = listagemDiretorios.Items.Count > 0;
            EnableControls(isEnabled: enable, isEnabledProcess: enable);
        }

        private async void Process_Click(object sender, EventArgs e)
        {
            if (listagemDiretorios.Items.Count == 0)
            {
                ShowErrorMessage("Selecione ao menos um diretório para continuar!");
                return;
            }

            var (success, messages) = await ExtractFilesAsync();
            if (!success)
            {
                StringBuilder message = new StringBuilder();
                foreach (var item in messages)
                {
                    message.AppendLine(item);
                }

                ShowErrorMessage(message.ToString());
            }
            else
            {
                ShowSuccessMessage("Arquivos descompactados com sucesso!");

                // Abrir a pasta selecionada
                string selectedDirectory = listagemDiretorios.Items.Cast<string>().FirstOrDefault() ?? "";
                if (!string.IsNullOrEmpty(selectedDirectory) && Directory.Exists(selectedDirectory))
                {
                    System.Diagnostics.Process.Start("explorer.exe", selectedDirectory);
                }
            }

            progressBar1.Value = 0;
            LabelProgressoText = string.Empty;
            lblProgresso.Text = LabelProgressoText;
            EnableControls(true);
        }


        private async Task<(bool success, IEnumerable<string> messages)> ExtractFilesAsync()
        {
            bool success = false;
            List<string> messages = new();

            try
            {
                EnableControls(false, false, false);

                currentDirectory.ResetText();

                int progressDirectories = 0;

                List<string> directories = listagemDiretorios.Items.Cast<string>().ToList();

                foreach (string directory in directories)
                {
                    if (Directory.Exists(directory))
                    {
                        string[] subDirectories = Directory.GetDirectories(directory, "*", SearchOption.AllDirectories);

                        if (subDirectories.Length == 0)
                        {
                            progressBar1.Maximum = directories.Count;
                            progressBar1.Value = progressDirectories;

                            progressDirectories += 1;

                            LabelProgressoText = $"Extraindo diretório {progressDirectories} de {directories.Count} - Extraindo {progressBar1.Value} de {progressBar1.Maximum} subdiretórios. $msg";

                            await ExtractFilesFromDirectory(directory);
                        }
                        else
                        {
                            progressBar1.Maximum = subDirectories.Length;
                            progressBar1.Value = 0;

                            progressDirectories += 1;

                            foreach (string subDirectory in subDirectories)
                            {
                                progressBar1.Value += 1;
                                LabelProgressoText = $"Extraindo diretório {progressDirectories} de {directories.Count} - Extraindo {progressBar1.Value} de {progressBar1.Maximum} subdiretórios. $msg";

                                await ExtractFilesFromDirectory(subDirectory);
                            }
                        }

                        UpdateUI();
                        success = true;
                    }
                    else
                    {
                        messages.Add($"O diretório {directory} não existe.");
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                messages.Add($"Erro durante a extração: {ex.Message}");
                success = false;
            }
            finally
            {
                EnableControls(true, true, true);
            }

            return (success, messages);
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

        private static IEnumerable<string> GetRarFilesInDirectory(string directory)
        {
            return Directory.GetFiles(directory)
                .Where(file => file.EndsWith(RarFileExtension));
        }

        private static void ExtractEntriesFromRarFile(string rarFile, string directory, Dictionary<string, DateTime> extractedFilesDictionary)
        {
            using var archive = RarArchive.Open(rarFile);
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

        private static ExtractionOptions GetExtractionOptions()
        {
            return new ExtractionOptions
            {
                ExtractFullPath = true,
                PreserveFileTime = true,
                Overwrite = true
            };
        }

        private static void DeleteRarFileIfRequired(string rarFile, bool deleteCompactadosChecked)
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

        private static void RenameFile(string originalName, string newName)
        {
            File.Move(originalName, newName);
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateUI()
        {
            Application.DoEvents();
            Refresh();
        }

        private async void CompactarBtn_Click(object sender, EventArgs e)
        {
            // Verificar se há itens no ListBox
            if (listagemDiretorios.Items.Count > 0)
            {
                // Obter o caminho da pasta no ListBox
                string pastaSelecionada = listagemDiretorios.Items[0].ToString(); // Use o primeiro item como exemplo

                // Definir o nome do arquivo compactado (zip) com base no nome da pasta
                string arquivoZip = Path.Combine(Path.GetDirectoryName(pastaSelecionada), $"{Path.GetFileName(pastaSelecionada)}.zip");

                try
                {
                    // Criar um novo arquivo Zip
                    using (FileStream zipToCreate = new FileStream(arquivoZip, FileMode.Create))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                        {
                            // Obter a lista de arquivos a serem compactados
                            string[] arquivos = Directory.GetFiles(pastaSelecionada, "*", SearchOption.AllDirectories);

                            // Definir o máximo da barra de progresso
                            progressBar1.Maximum = arquivos.Length;

                            // Compactar os arquivos
                            for (int i = 0; i < arquivos.Length; i++)
                            {
                                // Atualizar o progresso
                                progressBar1.Value = i + 1;

                                // Atualizar a label de progresso
                                lblProgresso.Text = $"Compactando arquivo {i + 1} de {arquivos.Length}";

                                // Obter o caminho do arquivo
                                string arquivo = arquivos[i];

                                // Obter o caminho relativo para o arquivo dentro do arquivo Zip
                                string entradaRelativa = arquivo.Substring(pastaSelecionada.Length + 1);

                                // Criar uma entrada no arquivo Zip
                                ZipArchiveEntry entry = archive.CreateEntry(entradaRelativa);

                                // Escrever os dados do arquivo para a entrada do arquivo Zip
                                using (FileStream fs = File.OpenRead(arquivo))
                                using (Stream es = entry.Open())
                                {
                                    await fs.CopyToAsync(es);
                                }
                            }

                            MessageBox.Show("Pasta compactada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao compactar a pasta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Resetar a barra de progresso
                    progressBar1.Value = 0;
                    // Resetar a label de progresso
                    lblProgresso.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Adicione pelo menos um diretório antes de compactar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    

        private void ContarBtn_Click(object sender, EventArgs e)
        {
            // Verificar se há itens no ListBox
            if (listagemDiretorios.Items.Count > 0)
            {
                // Obter o caminho do primeiro diretório no ListBox (você pode adaptar para percorrer todos os itens)
                string diretorioSelecionado = listagemDiretorios.Items[0].ToString();

                try
                {
                    int quantidadeDeArquivos = ContarArquivos(diretorioSelecionado);

                    MessageBox.Show($"O diretório '{diretorioSelecionado}' contém {quantidadeDeArquivos} arquivo(s).",
                                    "Contagem de Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao contar os arquivos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Adicione pelo menos um diretório antes de contar os arquivos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int ContarArquivos(string diretorio)
        {
            // Verificar se o diretório existe
            if (Directory.Exists(diretorio))
            {
                // Recursivamente contar arquivos nas subpastas
                int quantidadeDeArquivos = Directory.GetFiles(diretorio, "*", SearchOption.AllDirectories).Length;

                return quantidadeDeArquivos;
            }
            else
            {
                throw new DirectoryNotFoundException($"O diretório '{diretorio}' não existe.");
            }
        }
    }


}
