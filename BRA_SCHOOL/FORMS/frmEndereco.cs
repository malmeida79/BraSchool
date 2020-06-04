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
    public partial class frmEndereco : Form
    {
        // Declaracoes e objetos
        EntEndereco Endereco = new EntEndereco();
        BuEndereco objBu = new BuEndereco();
        BuBairro objBuBairro = new BuBairro();
        BuCidade objCidade = new BuCidade();
        BuEstado objEstado = new BuEstado();
        BuPais objBuPais = new BuPais();

        bool novoRegistro = false;

        public frmEndereco()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmEndereco_Load(object sender, EventArgs e)
        {
            Painel(true, true, true, false, false);
            novoRegistro = true;
            Languages.LoadIdioma(this);

            List<EntBairro> lstBairro = new List<EntBairro>();
            lstBairro = objBuBairro.Listar();

            // ALterar para construir a escadinha pais, estado, cidade, bairro
            cboBairro.DataSource = lstBairro;
            cboBairro.DisplayMember = "DescricaoBairro";
            cboBairro.ValueMember = "codBairro";

            cboBairro.SelectedIndex = -1;

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

            List<EntEndereco> lstEnderecos = new List<EntEndereco>();

            Painel(true, true, false, false, true);

            novoRegistro = false;

            Endereco.DescricaoEndereco = txtDescricao.Text;

            if (cboBairro.SelectedIndex >= 0)
            {
                Endereco.CodBairro = Convert.ToInt32(cboBairro.SelectedValue);
            }

            lstEnderecos = objBu.Pesquisar(Endereco);

            if (lstEnderecos.Count > 0)
            {
                dtgEndereco.DataSource = lstEnderecos;
                dtgEndereco.Columns[0].HeaderText = "Código";
                dtgEndereco.Columns[0].Visible = false;
                dtgEndereco.Columns[1].HeaderText = "Endereco";                
                dtgEndereco.Columns[2].HeaderText = "codBairro";
                dtgEndereco.Columns[2].Visible = false;
                dtgEndereco.Columns[3].HeaderText = "Bairro";
                dtgEndereco.Columns[4].HeaderText = "codEstado";
                dtgEndereco.Columns[4].Visible = false;
                dtgEndereco.Columns[5].HeaderText = "Estado";
                dtgEndereco.Columns[6].HeaderText = "codPais";
                dtgEndereco.Columns[6].Visible = false;
                dtgEndereco.Columns[7].HeaderText = "País";
            }
            else
            {
                Msg.MsgAlerta("Nenhuma Endereco localizado.");
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

            if(!Valida.SelecionadoItem(cboBairro.SelectedIndex)) {
                cboBairro.Focus();
                Msg.MsgErro("Selecione uma Bairro.");
                return;
            }

            Endereco.DescricaoEndereco = txtDescricao.Text;
            Endereco.CodBairro = Convert.ToInt32(cboBairro.SelectedValue);

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Endereco))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Endereco cadastrada.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Endereco.CodEndereco = Convert.ToInt32(txtCodEndereco.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Endereco))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Endereco alterada.");
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
            Endereco.CodEndereco = Convert.ToInt32(txtCodEndereco.Text);

            if (objBu.Excluir(Endereco))
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

        private void dtgEndereco_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodEndereco.Text = dtgEndereco[0, linha].Value.ToString();
            txtDescricao.Text = dtgEndereco[1, linha].Value.ToString();
            cboBairro.Text = dtgEndereco[3, linha].Value.ToString();

        }

        /// <summary>
        /// Reset de parametros ativos da tela
        /// </summary>
        private void ResetaDefaults()
        {

        }

        /// <summary>
        /// Finaliza Acao e restabelece Endereco inicial do form
        /// </summary>
        private void Finaliza()
        {
            novoRegistro = false;
            Limpeza.Controles(this);
            ResetaDefaults();
            Painel(true, true, false, false, false);
        }

        #endregion

        private void frmEndereco_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboBairro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
