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
    public partial class frmProfessor : Form
    {
        // Declaracoes e objetos
        EntProfessor Professor = new EntProfessor();
        BuProfessor objBuProfessor = new BuProfessor();
        BuNivelProfessor objBuNivelProfessor = new BuNivelProfessor();

        bool novoRegistro = false;

        public frmProfessor()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmProfessores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        private void frmProfessores_Load(object sender, EventArgs e)
        {
            Languages.LoadIdioma(this);

            Painel(true, true, true, false, false);
            novoRegistro = true;

            List<EntNivelProfessor> lstNivelProfessor = new List<EntNivelProfessor>();
            lstNivelProfessor = objBuNivelProfessor.Listar();

            cboNivelProfessor.DataSource = lstNivelProfessor;
            cboNivelProfessor.DisplayMember = "DescricaoNivelProfessor";
            cboNivelProfessor.ValueMember = "codNivelProfessor";

            cboNivelProfessor.SelectedIndex = -1;

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

            List<EntProfessor> lstProfessores = new List<EntProfessor>();
            Painel(true, true, false, false, true);

            novoRegistro = false;

            Professor.NomeProfessor = txtDescricao.Text;

            if (cboNivelProfessor.SelectedIndex >= 0)
            {
                Professor.CodNivelProfessor = Convert.ToInt32(cboNivelProfessor.SelectedValue);
            }

            lstProfessores = objBuProfessor.Pesquisar(Professor);

            if (lstProfessores.Count > 0)
            {
                dtgProfessores.DataSource = lstProfessores;
                dtgProfessores.Columns[0].HeaderText = "Código";
                dtgProfessores.Columns[0].Visible = false;
                dtgProfessores.Columns[1].HeaderText = "Nome";
                dtgProfessores.Columns[2].HeaderText = "CodNivelProfessor";
                dtgProfessores.Columns[2].Visible = false;
                dtgProfessores.Columns[3].HeaderText = "Nível";

            }
            else
            {
                Msg.MsgAlerta("Nenhum professor localizado.");
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (!Valida.EstaPreenchido(txtDescricao.Text))
            {
                txtDescricao.Focus();
                Msg.MsgErro("Preencha o nome corretamente.");
                return;
            }

            if (!Valida.SelecionadoItem(cboNivelProfessor.SelectedIndex))
            {
                cboNivelProfessor.Focus();
                Msg.MsgErro("Selecione um nivel para o professor.");
                return;
            }

            Professor.NomeProfessor = txtDescricao.Text;
            Professor.CodNivelProfessor = Convert.ToInt32(cboNivelProfessor.SelectedValue);

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBuProfessor.Cadastrar(Professor))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Professor cadastrado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Professor.CodProfessor = Convert.ToInt32(txtCodProfessores.Text);
                // Se atualizacao ocorreu corretamente
                if (objBuProfessor.Gravar(Professor))
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
            Professor.CodProfessor = Convert.ToInt32(txtCodProfessores.Text);

            if (objBuProfessor.Excluir(Professor))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de professor");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao do professor.");
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
            if (linha >= 0)
            {
                Painel(true, true, true, true, true);

                txtCodProfessores.Text = dtgProfessores[0, linha].Value.ToString();
                txtDescricao.Text = dtgProfessores[1, linha].Value.ToString();
                cboNivelProfessor.Text = dtgProfessores[3, linha].Value.ToString();

            }
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
