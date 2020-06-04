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
    public partial class frmBairro : Form
    {
        // Declaracoes e objetos
        EntBairro Bairro = new EntBairro();
        BuBairro objBu = new BuBairro();
        BuCidade objBuCidade = new BuCidade();
        bool novoRegistro = false;

        public frmBairro()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmBairro_Load(object sender, EventArgs e)
        {
            Painel(true, true, true, false, false);
            novoRegistro = true;
            Languages.LoadIdioma(this);

            List<EntCidade> lstCidade = new List<EntCidade>();
            lstCidade = objBuCidade.Listar();

            cboCidade.DataSource = lstCidade;
            cboCidade.DisplayMember = "DescricaoCidade";
            cboCidade.ValueMember = "CodCidade";

            cboCidade.SelectedIndex = -1;

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

            List<EntBairro> lstBairros = new List<EntBairro>();

            Painel(true, true, false, false, true);

            novoRegistro = false;

            Bairro.DescricaoBairro = txtDescricao.Text;

            if (cboCidade.SelectedIndex >= 0)
            {
                Bairro.CodCidade = Convert.ToInt32(cboCidade.SelectedValue);
            }

            lstBairros = objBu.Pesquisar(Bairro);

            if (lstBairros.Count > 0)
            {
                dtgBairro.DataSource = lstBairros;
                dtgBairro.Columns[0].HeaderText = "Código";
                dtgBairro.Columns[0].Visible = false;
                dtgBairro.Columns[1].HeaderText = "Bairro";                
                dtgBairro.Columns[2].HeaderText = "codCidade";
                dtgBairro.Columns[2].Visible = false;
                dtgBairro.Columns[3].HeaderText = "Cidade";
                dtgBairro.Columns[4].HeaderText = "codEstado";
                dtgBairro.Columns[4].Visible = false;
                dtgBairro.Columns[5].HeaderText = "Estado";
                dtgBairro.Columns[6].HeaderText = "codPais";
                dtgBairro.Columns[6].Visible = false;
                dtgBairro.Columns[7].HeaderText = "País";
            }
            else
            {
                Msg.MsgAlerta("Nenhuma Bairro localizado.");
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

            if(!Valida.SelecionadoItem(cboCidade.SelectedIndex)) {
                cboCidade.Focus();
                Msg.MsgErro("Selecione uma Cidade.");
                return;
            }

            Bairro.DescricaoBairro = txtDescricao.Text;
            Bairro.CodCidade = Convert.ToInt32(cboCidade.SelectedValue);

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Bairro))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Bairro cadastrada.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Bairro.CodBairro = Convert.ToInt32(txtCodBairro.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Bairro))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Bairro alterada.");
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
            Bairro.CodBairro = Convert.ToInt32(txtCodBairro.Text);

            if (objBu.Excluir(Bairro))
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

        private void dtgBairro_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodBairro.Text = dtgBairro[0, linha].Value.ToString();
            txtDescricao.Text = dtgBairro[1, linha].Value.ToString();
            cboCidade.Text = dtgBairro[3, linha].Value.ToString();

        }

        /// <summary>
        /// Reset de parametros ativos da tela
        /// </summary>
        private void ResetaDefaults()
        {

        }

        /// <summary>
        /// Finaliza Acao e restabelece Bairro inicial do form
        /// </summary>
        private void Finaliza()
        {
            novoRegistro = false;
            Limpeza.Controles(this);
            ResetaDefaults();
            Painel(true, true, false, false, false);
        }

        #endregion

        private void frmBairro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }
    }
}
