namespace RarExtractor
{
    partial class RarExtractor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RarExtractor));
            folderBrowserDialog1 = new FolderBrowserDialog();
            tab3 = new TabControl();
            tabDescompacta = new TabPage();
            lblProgresso = new Label();
            currentDirectory = new TextBox();
            chk_rename_default = new CheckBox();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            chk_deleteCompactados = new CheckBox();
            obtemDiretorios = new Button();
            listagemDiretorios = new ListBox();
            processa = new Button();
            tab3.SuspendLayout();
            tabDescompacta.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "Diretório Atual";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.SelectedPath = "C:\\\\";
            // 
            // tab3
            // 
            tab3.Controls.Add(tabDescompacta);
            tab3.Location = new Point(2, 3);
            tab3.Margin = new Padding(5);
            tab3.Name = "tab3";
            tab3.SelectedIndex = 0;
            tab3.Size = new Size(640, 543);
            tab3.TabIndex = 4;
            // 
            // tabDescompacta
            // 
            tabDescompacta.Controls.Add(lblProgresso);
            tabDescompacta.Controls.Add(currentDirectory);
            tabDescompacta.Controls.Add(chk_rename_default);
            tabDescompacta.Controls.Add(panel1);
            tabDescompacta.Controls.Add(chk_deleteCompactados);
            tabDescompacta.Controls.Add(obtemDiretorios);
            tabDescompacta.Controls.Add(listagemDiretorios);
            tabDescompacta.Controls.Add(processa);
            tabDescompacta.Location = new Point(4, 29);
            tabDescompacta.Margin = new Padding(5);
            tabDescompacta.Name = "tabDescompacta";
            tabDescompacta.Padding = new Padding(5);
            tabDescompacta.Size = new Size(632, 510);
            tabDescompacta.TabIndex = 1;
            tabDescompacta.Text = "Diretórios a serem extraídos.";
            tabDescompacta.UseVisualStyleBackColor = true;
            // 
            // lblProgresso
            // 
            lblProgresso.AutoSize = true;
            lblProgresso.ForeColor = Color.Blue;
            lblProgresso.Location = new Point(9, 433);
            lblProgresso.Name = "lblProgresso";
            lblProgresso.Size = new Size(42, 20);
            lblProgresso.TabIndex = 15;
            lblProgresso.Text = "label";
            // 
            // currentDirectory
            // 
            currentDirectory.Enabled = false;
            currentDirectory.Location = new Point(9, 320);
            currentDirectory.Margin = new Padding(5);
            currentDirectory.Multiline = true;
            currentDirectory.Name = "currentDirectory";
            currentDirectory.ScrollBars = ScrollBars.Vertical;
            currentDirectory.Size = new Size(607, 99);
            currentDirectory.TabIndex = 14;
            // 
            // chk_rename_default
            // 
            chk_rename_default.AutoSize = true;
            chk_rename_default.FlatStyle = FlatStyle.System;
            chk_rename_default.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            chk_rename_default.Location = new Point(14, 251);
            chk_rename_default.Margin = new Padding(5);
            chk_rename_default.Name = "chk_rename_default";
            chk_rename_default.Size = new Size(460, 21);
            chk_rename_default.TabIndex = 12;
            chk_rename_default.Text = "Selecione para renomear os arquivos default (config.ini e painel01_nfe.ini)";
            chk_rename_default.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(progressBar1);
            panel1.Location = new Point(9, 469);
            panel1.Margin = new Padding(5);
            panel1.Name = "panel1";
            panel1.Size = new Size(513, 25);
            panel1.TabIndex = 10;
            // 
            // progressBar1
            // 
            progressBar1.AccessibleRole = AccessibleRole.Alert;
            progressBar1.Location = new Point(5, 5);
            progressBar1.Margin = new Padding(5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(505, 15);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 9;
            // 
            // chk_deleteCompactados
            // 
            chk_deleteCompactados.AutoSize = true;
            chk_deleteCompactados.FlatStyle = FlatStyle.System;
            chk_deleteCompactados.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            chk_deleteCompactados.Location = new Point(13, 211);
            chk_deleteCompactados.Margin = new Padding(5);
            chk_deleteCompactados.Name = "chk_deleteCompactados";
            chk_deleteCompactados.Size = new Size(449, 21);
            chk_deleteCompactados.TabIndex = 8;
            chk_deleteCompactados.Text = "Selecione para deletar os arquivos compactados ao finalizar a extração";
            chk_deleteCompactados.UseVisualStyleBackColor = true;
            // 
            // obtemDiretorios
            // 
            obtemDiretorios.Image = (Image)resources.GetObject("obtemDiretorios.Image");
            obtemDiretorios.ImageAlign = ContentAlignment.MiddleLeft;
            obtemDiretorios.Location = new Point(515, 15);
            obtemDiretorios.Margin = new Padding(5);
            obtemDiretorios.Name = "obtemDiretorios";
            obtemDiretorios.Size = new Size(110, 52);
            obtemDiretorios.TabIndex = 7;
            obtemDiretorios.Text = "Procurar";
            obtemDiretorios.TextImageRelation = TextImageRelation.ImageBeforeText;
            obtemDiretorios.UseVisualStyleBackColor = true;
            obtemDiretorios.Click += GetDirectory_Click;
            // 
            // listagemDiretorios
            // 
            listagemDiretorios.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listagemDiretorios.FormattingEnabled = true;
            listagemDiretorios.ItemHeight = 20;
            listagemDiretorios.Location = new Point(14, 15);
            listagemDiretorios.Margin = new Padding(5);
            listagemDiretorios.MultiColumn = true;
            listagemDiretorios.Name = "listagemDiretorios";
            listagemDiretorios.SelectionMode = SelectionMode.MultiExtended;
            listagemDiretorios.Size = new Size(497, 184);
            listagemDiretorios.TabIndex = 6;
            listagemDiretorios.SelectedIndexChanged += DirectoryList_SelectedIndexChanged;
            // 
            // processa
            // 
            processa.Image = Properties.Resources.desc;
            processa.ImageAlign = ContentAlignment.MiddleLeft;
            processa.Location = new Point(525, 449);
            processa.Margin = new Padding(5);
            processa.Name = "processa";
            processa.Size = new Size(96, 45);
            processa.TabIndex = 5;
            processa.Text = "Extrair";
            processa.TextImageRelation = TextImageRelation.ImageBeforeText;
            processa.UseVisualStyleBackColor = true;
            processa.Click += Process_Click;
            // 
            // RarExtractor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 549);
            Controls.Add(tab3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "RarExtractor";
            Text = "RarExtractor";
            tab3.ResumeLayout(false);
            tabDescompacta.ResumeLayout(false);
            tabDescompacta.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private TabControl tab3;
        private TabPage tabDescompacta;
        private TextBox currentDirectory;
        private CheckBox chk_rename_default;
        private Panel panel1;
        private ProgressBar progressBar1;
        private CheckBox chk_deleteCompactados;
        private Button obtemDiretorios;
        private ListBox listagemDiretorios;
        private Button processa;
        private Label lblProgresso;
    }
}