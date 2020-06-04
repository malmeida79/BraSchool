namespace BRA_SCHOOL.FORMS
{
    partial class frmEndereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndereco));
            this.txtCodEndereco = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cboBairro = new System.Windows.Forms.ComboBox();
            this.cboCidade = new System.Windows.Forms.ComboBox();
            this.cboPais = new System.Windows.Forms.ComboBox();
            this.lblBairro = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblPais = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgEndereco = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEndereco)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodEndereco
            // 
            this.txtCodEndereco.Location = new System.Drawing.Point(317, 420);
            this.txtCodEndereco.Name = "txtCodEndereco";
            this.txtCodEndereco.Size = new System.Drawing.Size(29, 20);
            this.txtCodEndereco.TabIndex = 39;
            this.txtCodEndereco.Text = "0";
            this.txtCodEndereco.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.cboBairro);
            this.groupBox3.Controls.Add(this.cboCidade);
            this.groupBox3.Controls.Add(this.cboPais);
            this.groupBox3.Controls.Add(this.lblBairro);
            this.groupBox3.Controls.Add(this.cboEstado);
            this.groupBox3.Controls.Add(this.lblCidade);
            this.groupBox3.Controls.Add(this.lblPais);
            this.groupBox3.Controls.Add(this.lblEstado);
            this.groupBox3.Controls.Add(this.btnCancelar);
            this.groupBox3.Controls.Add(this.btnGravar);
            this.groupBox3.Controls.Add(this.btnExcluir);
            this.groupBox3.Controls.Add(this.btnPesquisar);
            this.groupBox3.Controls.Add(this.btnNovo);
            this.groupBox3.Controls.Add(this.txtDescricao);
            this.groupBox3.Controls.Add(this.lblNome);
            this.groupBox3.Location = new System.Drawing.Point(11, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(428, 185);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(78, 120);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 41;
            // 
            // cboBairro
            // 
            this.cboBairro.FormattingEnabled = true;
            this.cboBairro.Location = new System.Drawing.Point(78, 91);
            this.cboBairro.Name = "cboBairro";
            this.cboBairro.Size = new System.Drawing.Size(336, 21);
            this.cboBairro.TabIndex = 41;
            this.cboBairro.SelectedIndexChanged += new System.EventHandler(this.cboBairro_SelectedIndexChanged);
            // 
            // cboCidade
            // 
            this.cboCidade.FormattingEnabled = true;
            this.cboCidade.Location = new System.Drawing.Point(78, 64);
            this.cboCidade.Name = "cboCidade";
            this.cboCidade.Size = new System.Drawing.Size(336, 21);
            this.cboCidade.TabIndex = 41;
            this.cboCidade.SelectedIndexChanged += new System.EventHandler(this.cboCidade_SelectedIndexChanged);
            // 
            // cboPais
            // 
            this.cboPais.FormattingEnabled = true;
            this.cboPais.Location = new System.Drawing.Point(78, 13);
            this.cboPais.Name = "cboPais";
            this.cboPais.Size = new System.Drawing.Size(336, 21);
            this.cboPais.TabIndex = 41;
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(22, 97);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(37, 13);
            this.lblBairro.TabIndex = 40;
            this.lblBairro.Tag = "bairro";
            this.lblBairro.Text = "Bairro:";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(78, 39);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(336, 21);
            this.cboEstado.TabIndex = 41;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(22, 70);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(43, 13);
            this.lblCidade.TabIndex = 40;
            this.lblCidade.Tag = "cidade";
            this.lblCidade.Text = "Cidade:";
            // 
            // lblPais
            // 
            this.lblPais.AutoSize = true;
            this.lblPais.Location = new System.Drawing.Point(22, 16);
            this.lblPais.Name = "lblPais";
            this.lblPais.Size = new System.Drawing.Size(30, 13);
            this.lblPais.TabIndex = 40;
            this.lblPais.Tag = "pais";
            this.lblPais.Text = "Pais:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(22, 42);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 40;
            this.lblEstado.Tag = "estado";
            this.lblEstado.Text = "Estado:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(98, 152);
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
            this.btnGravar.Location = new System.Drawing.Point(260, 153);
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
            this.btnExcluir.Location = new System.Drawing.Point(341, 155);
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
            this.btnPesquisar.Location = new System.Drawing.Point(179, 154);
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
            this.btnNovo.Location = new System.Drawing.Point(15, 152);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 21;
            this.btnNovo.Tag = "novo";
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(179, 119);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(235, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(19, 123);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(56, 13);
            this.lblNome.TabIndex = 20;
            this.lblNome.Tag = "endereco";
            this.lblNome.Text = "Endereço:";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(355, 416);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 38;
            this.btnFechar.Tag = "fechar";
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgEndereco);
            this.groupBox1.Location = new System.Drawing.Point(8, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 225);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // dtgEndereco
            // 
            this.dtgEndereco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEndereco.Location = new System.Drawing.Point(10, 16);
            this.dtgEndereco.Name = "dtgEndereco";
            this.dtgEndereco.ReadOnly = true;
            this.dtgEndereco.Size = new System.Drawing.Size(410, 200);
            this.dtgEndereco.TabIndex = 1;
            this.dtgEndereco.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEndereco_CellClick);
            // 
            // frmEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 451);
            this.Controls.Add(this.txtCodEndereco);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEndereco";
            this.Tag = "frmEndereco";
            this.Text = ":: Cadastro de Endereços ::";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEndereco_FormClosing);
            this.Load += new System.EventHandler(this.frmEndereco_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEndereco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodEndereco;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtgEndereco;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboCidade;
        private System.Windows.Forms.ComboBox cboPais;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label lblPais;
        private System.Windows.Forms.ComboBox cboBairro;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}