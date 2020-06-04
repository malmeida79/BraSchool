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
    public partial class frmFuncionalidade : Form
    {
        // Declaracoes e objetos
        EntFuncionalidade Funcionalidade = new EntFuncionalidade();
        BuFuncionalidade objBu = new BuFuncionalidade();
        bool novoRegistro = false;

        public frmFuncionalidade()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmFuncionalidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        private void frmFuncionalidade_Load(object sender, EventArgs e)
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

            List<EntFuncionalidade> lstFuncionalidades = new List<EntFuncionalidade>();
            Painel(true, true, false, false, true);

            novoRegistro = false;

            Funcionalidade.DescricaoFuncionalidade = txtDescricao.Text;

            lstFuncionalidades = objBu.Pesquisar(Funcionalidade);

            if (lstFuncionalidades.Count > 0)
            {
                dtgFuncionalidade.DataSource = lstFuncionalidades;
                dtgFuncionalidade.Columns[0].HeaderText = "Código";
                dtgFuncionalidade.Columns[0].Visible = false;
                dtgFuncionalidade.Columns[1].HeaderText = "Funcionalidade";
            }
            else
            {
                Msg.MsgAlerta("Nenhum Funcionalidade localizado.");
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

            Funcionalidade.DescricaoFuncionalidade = txtDescricao.Text;

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Funcionalidade))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Funcionalidade cadastrado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Funcionalidade.CodFuncionalidade = Convert.ToInt32(txtCodFuncionalidade.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Funcionalidade))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Funcionalidade alterado.");
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
            Funcionalidade.CodFuncionalidade = Convert.ToInt32(txtCodFuncionalidade.Text);

            if (objBu.Excluir(Funcionalidade))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de Funcionalidade");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao do Funcionalidade.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgFuncionalidades_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodFuncionalidade.Text = dtgFuncionalidade[0, linha].Value.ToString();
            txtDescricao.Text = dtgFuncionalidade[1, linha].Value.ToString();
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
