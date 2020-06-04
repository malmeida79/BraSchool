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
    public partial class frmSalas : Form
    {
        // Declaracoes e objetos
        EntSala Sala = new EntSala();
        BuSala objBu = new BuSala();
        BuUnidade objBuUnidades = new BuUnidade();
        bool novoRegistro = false;

        public frmSalas()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmSalas_Load(object sender, EventArgs e)
        {
            Painel(true, true, true, false, false);
            novoRegistro = true;

            Languages.LoadIdioma(this);

            List<EntUnidade> lstUnidade = new List<EntUnidade>();
            lstUnidade = objBuUnidades.Listar();

            cboUnidades.DataSource = lstUnidade;
            cboUnidades.DisplayMember = "DescricaoUnidade";
            cboUnidades.ValueMember = "codUnidade";

            cboUnidades.SelectedIndex = -1;

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

            List<EntSala> lstSalas = new List<EntSala>();

            Painel(true, true, false, false, true);

            novoRegistro = false;

            Sala.DescricaoSala = txtDescricao.Text;

            if (cboUnidades.SelectedIndex >= 0)
            {
                Sala.CodUnidade = Convert.ToInt32(cboUnidades.SelectedValue);
            }

            lstSalas = objBu.Pesquisar(Sala);

            if (lstSalas.Count > 0)
            {
                dtgSala.DataSource = lstSalas;
                dtgSala.Columns[0].HeaderText = "Código";
                dtgSala.Columns[0].Visible = false;
                dtgSala.Columns[1].HeaderText = "Sala";                
                dtgSala.Columns[2].HeaderText = "codUnidade";
                dtgSala.Columns[2].Visible = false;
                dtgSala.Columns[3].HeaderText = "Unidade";
            }
            else
            {
                Msg.MsgAlerta("Nenhuma Sala localizado.");
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

            if(!Valida.SelecionadoItem(cboUnidades.SelectedIndex)) {
                cboUnidades.Focus();
                Msg.MsgErro("Selecione uma unidade.");
                return;
            }

            Sala.DescricaoSala = txtDescricao.Text;
            Sala.CodUnidade = Convert.ToInt32(cboUnidades.SelectedValue);

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Sala))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Sala cadastrada.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Sala.CodSala = Convert.ToInt32(txtCodSala.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Sala))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Sala alterada.");
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
            Sala.CodSala = Convert.ToInt32(txtCodSala.Text);

            if (objBu.Excluir(Sala))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de curso");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao do curso.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgSala_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodSala.Text = dtgSala[0, linha].Value.ToString();
            txtDescricao.Text = dtgSala[1, linha].Value.ToString();
            cboUnidades.Text = dtgSala[3, linha].Value.ToString();

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

        private void frmSalas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }
    }
}
