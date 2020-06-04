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
    public partial class frmEstado : Form
    {
        // Declaracoes e objetos
        EntEstado Estado = new EntEstado();
        BuEstado objBu = new BuEstado();
        BuPais objBuPais = new BuPais();
        bool novoRegistro = false;

        public frmEstado()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmEstado_Load(object sender, EventArgs e)
        {
            Painel(true, true, true, false, false);
            novoRegistro = true;
            Languages.LoadIdioma(this);

            List<EntPais> lstPais = new List<EntPais>();
            lstPais = objBuPais.Listar();

            cboPais.DataSource = lstPais;
            cboPais.DisplayMember = "DescricaoPais";
            cboPais.ValueMember = "codPais";

            cboPais.SelectedIndex = -1;

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

            List<EntEstado> lstEstados = new List<EntEstado>();

            Painel(true, true, false, false, true);

            novoRegistro = false;

            Estado.DescricaoEstado = txtDescricao.Text;

            if (cboPais.SelectedIndex >= 0)
            {
                Estado.CodPais = Convert.ToInt32(cboPais.SelectedValue);
            }

            lstEstados = objBu.Pesquisar(Estado);

            if (lstEstados.Count > 0)
            {
                dtgEstado.DataSource = lstEstados;
                dtgEstado.Columns[0].HeaderText = "Código";
                dtgEstado.Columns[0].Visible = false;
                dtgEstado.Columns[1].HeaderText = "Estado";                
                dtgEstado.Columns[2].HeaderText = "codPais";
                dtgEstado.Columns[2].Visible = false;
                dtgEstado.Columns[3].HeaderText = "Pais";
            }
            else
            {
                Msg.MsgAlerta("Nenhuma Estado localizado.");
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

            if(!Valida.SelecionadoItem(cboPais.SelectedIndex)) {
                cboPais.Focus();
                Msg.MsgErro("Selecione uma Pais.");
                return;
            }

            Estado.DescricaoEstado = txtDescricao.Text;
            Estado.CodPais = Convert.ToInt32(cboPais.SelectedValue);

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Estado))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Estado cadastrada.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Estado.CodEstado = Convert.ToInt32(txtCodEstado.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Estado))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Estado alterada.");
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
            Estado.CodEstado = Convert.ToInt32(txtCodEstado.Text);

            if (objBu.Excluir(Estado))
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

        private void dtgEstado_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodEstado.Text = dtgEstado[0, linha].Value.ToString();
            txtDescricao.Text = dtgEstado[1, linha].Value.ToString();
            cboPais.Text = dtgEstado[3, linha].Value.ToString();

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

        private void frmEstado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }
    }
}
