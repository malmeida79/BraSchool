using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BRA_SCHOOL.Opcoes;
using BRA_SCHOOL.BU;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.UTILS;

namespace BRA_SCHOOL.FORMS
{
    public partial class frmUsuario : Form
    {
        // Declaracoes e objetos
        EntUsuario Usuario = new EntUsuario();
        BuUsuario objBu = new BuUsuario();
        bool novoRegistro = false;

        public frmUsuario()
        {
            InitializeComponent();
        }

        #region "Eventos"

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            Painel(true, true, true, false, false);
            novoRegistro = true;
            Languages.LoadIdioma(this);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Painel(false, false, true, false, true);
            novoRegistro = true;
            Limpeza.Controles(this);
            ResetaDefaults();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            List<EntUsuario> lstUser = new List<EntUsuario>();
            Painel(true, true, false, false, true);

            novoRegistro = false;

            Usuario.NomeUsuario = txtNome.Text;
            Usuario.EmailUsuario = txtEmail.Text;
            Usuario.LoginUsuario = txtLogin.Text;
            Usuario.SenhaUsuario = txtSenha.Text;            
            Usuario.BloqueadoUsuario = (chkBloqueado.Checked) ? true : false;
            Usuario.AtivoUsuario = (chkAtivo.Checked) ? true : false;

            lstUser = objBu.Pesquisar(Usuario);

            if (lstUser.Count > 0)
            {
                dtgUsuarios.DataSource = lstUser;
                dtgUsuarios.Columns[0].HeaderText = "Código";
                dtgUsuarios.Columns[0].Visible = false;
                dtgUsuarios.Columns[1].HeaderText = "Login";
                dtgUsuarios.Columns[2].HeaderText = "Nome";
                dtgUsuarios.Columns[3].HeaderText = "Email";               
                dtgUsuarios.Columns[4].HeaderText = "Bloqueado";
                dtgUsuarios.Columns[5].HeaderText = "Ativo";
                dtgUsuarios.Columns[6].Visible = false;
            }
            else
            {
                Msg.MsgAlerta("Nenhum usuário localizado.");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Painel(true, true, false, false, false);
            novoRegistro = false;
            Limpeza.Controles(this);
            ResetaDefaults();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (!Valida.EstaPreenchido(txtNome.Text))
            {
                txtNome.Focus();
                Msg.MsgErro("Preencha o nome corretamente.");
                return;
            }

            if (!Valida.EstaPreenchido(txtLogin.Text))
            {
                txtLogin.Focus();
                Msg.MsgErro("Preencha o login corretamente.");
                return;
            }

            if (!Valida.EstaPreenchido(txtEmail.Text))
            {
                txtEmail.Focus();
                Msg.MsgErro("Preencha o email corretamente.");
                return;
            }

            if (!Valida.EstaPreenchido(txtSenha.Text))
            {
                txtSenha.Focus();
                Msg.MsgErro("Preencha a senha corretamente.");
                return;
            }

            if (!Valida.EstaPreenchido(txtConfirmacao.Text))
            {
                txtConfirmacao.Focus();
                Msg.MsgErro("Preencha a confirmação da senha corretamente.");
                return;
            }

            if (!Valida.ComparaValores(txtSenha.Text, txtConfirmacao.Text))
            {
                txtSenha.Focus();
                Msg.MsgErro("Senha e confirmação estão diferentes.");
                return;
            }

            // Carregando a entidade
            Usuario.NomeUsuario = txtNome.Text;
            Usuario.EmailUsuario = txtEmail.Text;
            Usuario.LoginUsuario = txtLogin.Text;
            Usuario.SenhaUsuario = txtSenha.Text;
            Usuario.BloqueadoUsuario = (chkBloqueado.Checked) ? true : false;
            Usuario.AtivoUsuario = (chkAtivo.Checked) ? true : false;

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Usuario))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Usuario cadastrado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                    LogFile.RegistraLog("Erro no cadastro de usuario.");
                }
            }
            else
            {
                Usuario.CodUsuario = Convert.ToInt32(txtCodUsuario.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Usuario))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Usuario alterado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                    LogFile.RegistraLog("Erro na gravação de usuario.");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Usuario.CodUsuario = Convert.ToInt32(txtCodUsuario.Text);

            if (objBu.Excluir(Usuario))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de usuario");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao de usuario.");
            }
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.Text = txtLogin.Text.ToUpper();
        }

        private void dtgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulaTela(e.RowIndex);
        }

        private void frmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        #endregion

        #region "Metodos do Form"

        /// <summary>
        /// Metodo para controlar os botoes da tela
        /// </summary>
        /// <param name="novo">Ativa desatiava botao</param>
        /// <param name="pesquisar">Ativa desatiava botao</param>
        /// <param name="gravar">Ativa desatiava botao</param>
        /// <param name="excliur">Ativa desatiava botao</param>
        /// <param name="cancela">Ativa desatiava botao</param>
        private void Painel(bool novo, bool pesquisar, bool gravar, bool excluir, bool cancela)
        {
            btnNovo.Enabled = novo;
            btnExcluir.Enabled = excluir;
            btnPesquisar.Enabled = pesquisar;
            btnGravar.Enabled = gravar;
            btnCancelar.Enabled = cancela;
        }

        /// <summary>
        /// Popula a tela com os dados selecionados no GRID
        /// </summary>
        /// <param name="linha"></param>
        private void PopulaTela(int linha)
        {
            if (linha > 0)
            {

                Painel(true, true, true, true, true);

                txtCodUsuario.Text = dtgUsuarios[0, linha].Value.ToString();
                txtLogin.Text = dtgUsuarios[1, linha].Value.ToString();
                txtNome.Text = dtgUsuarios[2, linha].Value.ToString();
                txtEmail.Text = dtgUsuarios[3, linha].Value.ToString();              
                chkBloqueado.Checked = Convert.ToBoolean(dtgUsuarios[4, linha].Value);
                chkAtivo.Checked = Convert.ToBoolean(dtgUsuarios[5, linha].Value);
                txtSenha.Text = dtgUsuarios[6, linha].Value.ToString();
                txtConfirmacao.Text = dtgUsuarios[6, linha].Value.ToString();

            }
        }

        /// <summary>
        /// Reset de parametros ativos da tela
        /// </summary>
        private void ResetaDefaults()
        {
            chkAtivo.Checked = true;
            txtCodUsuario.Text = "0";
        }

        /// <summary>
        /// Finaliza Acao e restabelece estado inicial do form
        /// </summary>
        private void Finaliza()
        {
            novoRegistro = false;
            Limpeza.Controles(this);
            ResetaDefaults();
            Painel(true, true, false, false, false);
        }

        #endregion

    }
}
