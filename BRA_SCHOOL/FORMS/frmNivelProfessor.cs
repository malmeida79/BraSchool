using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRA_SCHOOL.Opcoes;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.BU;
using BRA_SCHOOL.UTILS;

namespace BRA_SCHOOL.FORMS
{
    public partial class frmNivelProfessor : Form
    {
        // Declaracoes e objetos
        EntNivelProfessor NivelProfessor = new EntNivelProfessor();
        BuNivelProfessor objBu = new BuNivelProfessor();
        bool novoRegistro = false;

        public frmNivelProfessor()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmNivelProfessor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        private void frmNivelProfessor_Load(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Painel(true, true, false, false, false);
            novoRegistro = false;
            Limpeza.Controles(this);
            ResetaDefaults();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            List<EntNivelProfessor> lstProfessores = new List<EntNivelProfessor>();
            Painel(true, true, false, false, true);

            novoRegistro = false;

            NivelProfessor.DescricaoNivel = txtDescricao.Text;

            lstProfessores = objBu.Pesquisar(NivelProfessor);

            if (lstProfessores.Count > 0)
            {
                dtgNivelProfessores.DataSource = lstProfessores;
                dtgNivelProfessores.Columns[0].HeaderText = "Código";
                dtgNivelProfessores.Columns[0].Visible = false;
                dtgNivelProfessores.Columns[1].HeaderText = "Nivel";
            }
            else
            {
                Msg.MsgAlerta("Nenhum nivel de professor localizado.");
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (!Valida.EstaPreenchido(txtDescricao.Text))
            {
                txtDescricao.Focus();
                Msg.MsgErro("Preencha a descrição corretamente.");
                return;
            }

            NivelProfessor.DescricaoNivel = txtDescricao.Text;

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(NivelProfessor))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Nivel de Professor cadastrado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                NivelProfessor.CodNivelProfessor = Convert.ToInt32(txtCodNivelProfessor.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(NivelProfessor))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Professor alterado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            NivelProfessor.CodNivelProfessor = Convert.ToInt32(txtCodNivelProfessor.Text);

            if (objBu.Excluir(NivelProfessor))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de nivel de professor");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao do nivel de professor.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgPaises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulaTela(e.RowIndex);
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

            Painel(true, true, true, true, true);

            txtCodNivelProfessor.Text = dtgNivelProfessores[0, linha].Value.ToString();
            txtDescricao.Text = dtgNivelProfessores[1, linha].Value.ToString();
        }

        /// <summary>
        /// Reset de parametros ativos da tela
        /// </summary>
        private void ResetaDefaults()
        {

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
