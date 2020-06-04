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
    public partial class frmCidade : Form
    {
        // Declaracoes e objetos
        EntCidade Cidade = new EntCidade();
        BuCidade objBu = new BuCidade();
        BuEstado objBuEstado = new BuEstado();
        bool novoRegistro = false;

        public frmCidade()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmCidade_Load(object sender, EventArgs e)
        {
            Painel(true, true, true, false, false);
            novoRegistro = true;
            Languages.LoadIdioma(this);

            List<EntEstado> lstEstado = new List<EntEstado>();
            lstEstado = objBuEstado.Listar();

            cboEstado.DataSource = lstEstado;
            cboEstado.DisplayMember = "DescricaoEstado";
            cboEstado.ValueMember = "codEstado";

            cboEstado.SelectedIndex = -1;

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

            List<EntCidade> lstCidades = new List<EntCidade>();

            Painel(true, true, false, false, true);

            novoRegistro = false;

            Cidade.DescricaoCidade = txtDescricao.Text;

            if (cboEstado.SelectedIndex >= 0)
            {
                Cidade.CodEstado = Convert.ToInt32(cboEstado.SelectedValue);
            }

            lstCidades = objBu.Pesquisar(Cidade);

            if (lstCidades.Count > 0)
            {
                dtgCidade.DataSource = lstCidades;
                dtgCidade.Columns[0].HeaderText = "Código";
                dtgCidade.Columns[0].Visible = false;
                dtgCidade.Columns[1].HeaderText = "Cidade";                
                dtgCidade.Columns[2].HeaderText = "codEstado";
                dtgCidade.Columns[2].Visible = false;
                dtgCidade.Columns[3].HeaderText = "Estado";
                dtgCidade.Columns[4].HeaderText = "codPais";
                dtgCidade.Columns[4].Visible = false;
                dtgCidade.Columns[5].HeaderText = "País";
            }
            else
            {
                Msg.MsgAlerta("Nenhuma Cidade localizado.");
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

            if(!Valida.SelecionadoItem(cboEstado.SelectedIndex)) {
                cboEstado.Focus();
                Msg.MsgErro("Selecione uma Estado.");
                return;
            }

            Cidade.DescricaoCidade = txtDescricao.Text;
            Cidade.CodEstado = Convert.ToInt32(cboEstado.SelectedValue);

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Cidade))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Cidade cadastrada.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Cidade.CodCidade = Convert.ToInt32(txtCodCidade.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Cidade))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Cidade alterada.");
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
            Cidade.CodCidade = Convert.ToInt32(txtCodCidade.Text);

            if (objBu.Excluir(Cidade))
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

        private void dtgCidade_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodCidade.Text = dtgCidade[0, linha].Value.ToString();
            txtDescricao.Text = dtgCidade[1, linha].Value.ToString();
            cboEstado.Text = dtgCidade[3, linha].Value.ToString();

        }

        /// <summary>
        /// Reset de parametros ativos da tela
        /// </summary>
        private void ResetaDefaults()
        {

        }

        /// <summary>
        /// Finaliza Acao e restabelece Cidade inicial do form
        /// </summary>
        private void Finaliza()
        {
            novoRegistro = false;
            Limpeza.Controles(this);
            ResetaDefaults();
            Painel(true, true, false, false, false);
        }

        #endregion

        private void frmCidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }
    }
}
