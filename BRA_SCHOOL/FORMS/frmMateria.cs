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
    public partial class frmMateria : Form
    {
        // Declaracoes e objetos
        EntMateria Materia = new EntMateria();
        BuMateria objBu = new BuMateria();
        bool novoRegistro = false;

        public frmMateria()
        {
            InitializeComponent();
        }

        #region "Eventos"
        private void frmPaises_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }

        private void frmPaises_Load(object sender, EventArgs e)
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

            List<EntMateria> lstMaterias = new List<EntMateria>();
            Painel(true, true, false, false, true);

            novoRegistro = false;

            Materia.DescricaoMateria = txtDescricao.Text;

            lstMaterias = objBu.Pesquisar(Materia);

            if (lstMaterias.Count > 0)
            {
                dtgMaterias.DataSource = lstMaterias;
                dtgMaterias.Columns[0].HeaderText = "Código";
                dtgMaterias.Columns[0].Visible = false;
                dtgMaterias.Columns[1].HeaderText = "Disciplina";
            }
            else
            {
                Msg.MsgAlerta("Nenhuma disciplina localizado.");
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

            Materia.DescricaoMateria = txtDescricao.Text;

            // se novo registro
            if (novoRegistro)
            {
                // Se cadastro ocorreu corretamente
                if (objBu.Cadastrar(Materia))
                {
                    Msg.MsgAlerta("Dados cadastrados com sucesso.");
                    LogFile.RegistraLog("Disciplina cadastrada.");
                    Finaliza();
                }
                else
                {
                    Msg.MsgAlerta("Falha na gravação dos dados.");
                }
            }
            else
            {
                Materia.CodMateria = Convert.ToInt32(txtCodMaterias.Text);
                // Se atualizacao ocorreu corretamente
                if (objBu.Gravar(Materia))
                {
                    Msg.MsgAlerta("Dados salvos com sucesso.");
                    LogFile.RegistraLog("Disciplina alterada.");
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
            Materia.CodMateria = Convert.ToInt32(txtCodMaterias.Text);

            if (objBu.Excluir(Materia))
            {
                Msg.MsgAlerta("Dados excluídos com sucesso.");
                LogFile.RegistraLog("Exclusao de disciplina");
                Finaliza();
            }
            else
            {
                Msg.MsgAlerta("Falha na exclusão dos dados.");
                LogFile.RegistraLog("Erro na exclusao da disciplina.");
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

            txtCodMaterias.Text = dtgMaterias[0, linha].Value.ToString();
            txtDescricao.Text = dtgMaterias[1, linha].Value.ToString();
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
