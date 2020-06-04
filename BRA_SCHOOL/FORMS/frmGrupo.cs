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
    public partial class frmGrupo : Form
    {
        // Declaracoes e objetos
        EntGrupo Grupo = new EntGrupo();
        BuGrupo objBu = new BuGrupo();
        bool novoRegistro = false;

        public frmGrupo()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmGrupo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        private void frmGrupo_Load(object sender, EventArgs e)
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

            List<EntGrupo> lstGrupos = new List<EntGrupo>();
            Painel(true, true, false, false, true);

            novoRegistro = false;

            Grupo.DescricaoGrupo = txtDescricao.Text;

            lstGrupos = objBu.Pesquisar(Grupo);

            if (lstGrupos.Count > 0)
            {
                dtgGrupos.DataSource = lstGrupos;
                dtgGrupos.Columns[0].HeaderText = "Código";
                dtgGrupos.Columns[0].Visible = false;
                dtgGrupos.Columns[1].HeaderText = "Grupo";
            }
            else
            {
                Msg.MsgAlerta("Nenhum Grupo localizado.");
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

            Grupo.DescricaoGrupo = txtDescricao.Text;

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Grupo))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Grupo cadastrado.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Grupo.CodGrupo = Convert.ToInt32(txtCodGrupo.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Grupo))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Grupo alterado.");
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
            Grupo.CodGrupo = Convert.ToInt32(txtCodGrupo.Text);

            if (objBu.Excluir(Grupo))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de Grupo");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao do Grupo.");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
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

            txtCodGrupo.Text = dtgGrupos[0, linha].Value.ToString();
            txtDescricao.Text = dtgGrupos[1, linha].Value.ToString();
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
