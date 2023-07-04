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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tab3 = new System.Windows.Forms.TabControl();
            this.tabDescompacta = new System.Windows.Forms.TabPage();
            this.currentDirectory = new System.Windows.Forms.TextBox();
            this.chk_rename_default = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chk_deleteCompactados = new System.Windows.Forms.CheckBox();
            this.obtemDiretorios = new System.Windows.Forms.Button();
            this.listagemDiretorios = new System.Windows.Forms.ListBox();
            this.processa = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.tab3.SuspendLayout();
            this.tabDescompacta.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Diretório Atual";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\\\";
            // 
            // tab3
            // 
            this.tab3.Controls.Add(this.tabDescompacta);
            this.tab3.Location = new System.Drawing.Point(2, 2);
            this.tab3.Margin = new System.Windows.Forms.Padding(4);
            this.tab3.Name = "tab3";
            this.tab3.SelectedIndex = 0;
            this.tab3.Size = new System.Drawing.Size(560, 407);
            this.tab3.TabIndex = 4;
            // 
            // tabDescompacta
            // 
            this.tabDescompacta.Controls.Add(this.lblProgresso);
            this.tabDescompacta.Controls.Add(this.currentDirectory);
            this.tabDescompacta.Controls.Add(this.chk_rename_default);
            this.tabDescompacta.Controls.Add(this.panel1);
            this.tabDescompacta.Controls.Add(this.chk_deleteCompactados);
            this.tabDescompacta.Controls.Add(this.obtemDiretorios);
            this.tabDescompacta.Controls.Add(this.listagemDiretorios);
            this.tabDescompacta.Controls.Add(this.processa);
            this.tabDescompacta.Location = new System.Drawing.Point(4, 24);
            this.tabDescompacta.Margin = new System.Windows.Forms.Padding(4);
            this.tabDescompacta.Name = "tabDescompacta";
            this.tabDescompacta.Padding = new System.Windows.Forms.Padding(4);
            this.tabDescompacta.Size = new System.Drawing.Size(552, 379);
            this.tabDescompacta.TabIndex = 1;
            this.tabDescompacta.Text = "Diretórios a serem extraídos.";
            this.tabDescompacta.UseVisualStyleBackColor = true;
            // 
            // currentDirectory
            // 
            this.currentDirectory.Enabled = false;
            this.currentDirectory.Location = new System.Drawing.Point(8, 240);
            this.currentDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.currentDirectory.Multiline = true;
            this.currentDirectory.Name = "currentDirectory";
            this.currentDirectory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.currentDirectory.Size = new System.Drawing.Size(532, 75);
            this.currentDirectory.TabIndex = 14;
            // 
            // chk_rename_default
            // 
            this.chk_rename_default.AutoSize = true;
            this.chk_rename_default.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_rename_default.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chk_rename_default.Location = new System.Drawing.Point(12, 188);
            this.chk_rename_default.Margin = new System.Windows.Forms.Padding(4);
            this.chk_rename_default.Name = "chk_rename_default";
            this.chk_rename_default.Size = new System.Drawing.Size(440, 20);
            this.chk_rename_default.TabIndex = 12;
            this.chk_rename_default.Text = "Selecione para renomear os arquivos default (config.ini e painel01_nfe.ini)";
            this.chk_rename_default.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(8, 352);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 19);
            this.panel1.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.progressBar1.Location = new System.Drawing.Point(4, 4);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(442, 11);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 9;
            // 
            // chk_deleteCompactados
            // 
            this.chk_deleteCompactados.AutoSize = true;
            this.chk_deleteCompactados.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_deleteCompactados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chk_deleteCompactados.Location = new System.Drawing.Point(11, 158);
            this.chk_deleteCompactados.Margin = new System.Windows.Forms.Padding(4);
            this.chk_deleteCompactados.Name = "chk_deleteCompactados";
            this.chk_deleteCompactados.Size = new System.Drawing.Size(422, 20);
            this.chk_deleteCompactados.TabIndex = 8;
            this.chk_deleteCompactados.Text = "Selecione para deletar os arquivos compactados ao finalizar a extração";
            this.chk_deleteCompactados.UseVisualStyleBackColor = true;
            // 
            // obtemDiretorios
            // 
            this.obtemDiretorios.Location = new System.Drawing.Point(456, 7);
            this.obtemDiretorios.Margin = new System.Windows.Forms.Padding(4);
            this.obtemDiretorios.Name = "obtemDiretorios";
            this.obtemDiretorios.Size = new System.Drawing.Size(88, 26);
            this.obtemDiretorios.TabIndex = 7;
            this.obtemDiretorios.Text = "Procurar";
            this.obtemDiretorios.UseVisualStyleBackColor = true;
            this.obtemDiretorios.Click += new System.EventHandler(this.GetDirectory_Click);
            // 
            // listagemDiretorios
            // 
            this.listagemDiretorios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listagemDiretorios.FormattingEnabled = true;
            this.listagemDiretorios.ItemHeight = 15;
            this.listagemDiretorios.Location = new System.Drawing.Point(12, 11);
            this.listagemDiretorios.Margin = new System.Windows.Forms.Padding(4);
            this.listagemDiretorios.MultiColumn = true;
            this.listagemDiretorios.Name = "listagemDiretorios";
            this.listagemDiretorios.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listagemDiretorios.Size = new System.Drawing.Size(436, 139);
            this.listagemDiretorios.TabIndex = 6;
            this.listagemDiretorios.SelectedIndexChanged += new System.EventHandler(this.DirectoryList_SelectedIndexChanged);
            // 
            // processa
            // 
            this.processa.Location = new System.Drawing.Point(459, 344);
            this.processa.Margin = new System.Windows.Forms.Padding(4);
            this.processa.Name = "processa";
            this.processa.Size = new System.Drawing.Size(84, 26);
            this.processa.TabIndex = 5;
            this.processa.Text = "Extrair";
            this.processa.UseVisualStyleBackColor = true;
            this.processa.Click += new System.EventHandler(this.Process_Click);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Location = new System.Drawing.Point(8, 325);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(32, 15);
            this.lblProgresso.TabIndex = 15;
            this.lblProgresso.Text = "label";
            // 
            // RarExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 412);
            this.Controls.Add(this.tab3);
            this.Name = "RarExtractor";
            this.Text = "RarExtractor";
            this.tab3.ResumeLayout(false);
            this.tabDescompacta.ResumeLayout(false);
            this.tabDescompacta.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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