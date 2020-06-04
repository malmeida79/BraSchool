namespace BRA_SCHOOL.FORMS
{
    partial class frmExport
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboArquivo = new System.Windows.Forms.ComboBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveDiag = new System.Windows.Forms.SaveFileDialog();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExport);
            this.groupBox3.Controls.Add(this.cboArquivo);
            this.groupBox3.Controls.Add(this.lblCidade);
            this.groupBox3.Controls.Add(this.btnSelecionar);
            this.groupBox3.Location = new System.Drawing.Point(11, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 109);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            // 
            // cboArquivo
            // 
            this.cboArquivo.FormattingEnabled = true;
            this.cboArquivo.Location = new System.Drawing.Point(78, 21);
            this.cboArquivo.Name = "cboArquivo";
            this.cboArquivo.Size = new System.Drawing.Size(302, 21);
            this.cboArquivo.TabIndex = 41;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(22, 24);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(46, 13);
            this.lblCidade.TabIndex = 40;
            this.lblCidade.Tag = "arquivo";
            this.lblCidade.Text = "Arquivo:";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(82, 62);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(217, 23);
            this.btnSelecionar.TabIndex = 21;
            this.btnSelecionar.Tag = "selecionaArquivo";
            this.btnSelecionar.Text = "Selecione pasta Destino e Formato";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(316, 129);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 39;
            this.btnFechar.Tag = "fechar";
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(305, 62);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 42;
            this.btnExport.Tag = "exportar";
            this.btnExport.Text = "Exrportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 175);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.Tag = "frmExport";
            this.Text = ":: Exportação de Arquivos ::";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExport_FormClosing);
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboArquivo;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveDiag;
    }
}