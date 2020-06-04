namespace BRA_SCHOOL.FORMS
{
    partial class frmProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfessor));
            this.txtCodProfessores = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboNivelProfessor = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgProfessores = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProfessores)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodProfessores
            // 
            this.txtCodProfessores.Location = new System.Drawing.Point(315, 361);
            this.txtCodProfessores.Name = "txtCodProfessores";
            this.txtCodProfessores.Size = new System.Drawing.Size(29, 20);
            this.txtCodProfessores.TabIndex = 35;
            this.txtCodProfessores.Text = "0";
            this.txtCodProfessores.Visible = false;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(63, 14);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(351, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(353, 357);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Tag = "fechar";
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboNivelProfessor);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.btnGravar);
            this.groupBox3.Controls.Add(this.btnExcluir);
            this.groupBox3.Controls.Add(this.btnPesquisar);
            this.groupBox3.Controls.Add(this.btnNovo);
            this.groupBox3.Controls.Add(this.txtDescricao);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblNome);
            this.groupBox3.Location = new System.Drawing.Point(9, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 119);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // cboNivelProfessor
            // 
            this.cboNivelProfessor.FormattingEnabled = true;
            this.cboNivelProfessor.Location = new System.Drawing.Point(65, 44);
            this.cboNivelProfessor.Name = "cboNivelProfessor";
            this.cboNivelProfessor.Size = new System.Drawing.Size(349, 21);
            this.cboNivelProfessor.TabIndex = 26;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(98, 82);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Tag = "cancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(260, 82);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 24;
            this.btnGravar.Tag = "gravar";
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(341, 82);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 25;
            this.btnExcluir.Tag = "excluir";
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(179, 82);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 23;
            this.btnPesquisar.Tag = "pesquisar";
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(15, 82);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 21;
            this.btnNovo.Tag = "novo";
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 20;
            this.label1.Tag = "nivel";
            this.label1.Text = "Nível:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(19, 17);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 20;
            this.lblNome.Tag = "nome";
            this.lblNome.Text = "Nome:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgProfessores);
            this.groupBox1.Location = new System.Drawing.Point(6, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 225);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // dtgProfessores
            // 
            this.dtgProfessores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProfessores.Location = new System.Drawing.Point(10, 16);
            this.dtgProfessores.Name = "dtgProfessores";
            this.dtgProfessores.ReadOnly = true;
            this.dtgProfessores.Size = new System.Drawing.Size(410, 200);
            this.dtgProfessores.TabIndex = 1;
            this.dtgProfessores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPaises_CellClick);
            // 
            // frmProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 387);
            this.Controls.Add(this.txtCodProfessores);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProfessor";
            this.Tag = "frmProfessor";
            this.Text = ":: Cadastro de Professores ::";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProfessores_FormClosing);
            this.Load += new System.EventHandler(this.frmProfessores_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProfessores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodProfessores;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgProfessores;
        private System.Windows.Forms.ComboBox cboNivelProfessor;
        private System.Windows.Forms.Label label1;

    }
}