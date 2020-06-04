using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRA_SCHOOL.Opcoes;
using BRA_SCHOOL.FORMS;
using BRA_SCHOOL.UTILS;

namespace BRA_SCHOOL.FORMS
{
    public partial class frmPrincipal : Form
    {
        public string dataAtual;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dataAtual = DateTime.Now.ToShortDateString();
            this.Text = string.Format(":: BRA-SCHOOL :: - [{0}] em {1}", Logado.logadoLogin, dataAtual);
            lblStatus1.Text = "Versão: " + Application.ProductVersion.ToString();
            Languages.LoadIdioma(this);
        }

        private void encerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Msg.Confirmacao("Deseja realmente finalizar?"))
            {
                LogFile.RegistraLog("Sistema finalizado.");
                Application.Exit();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmUsuario(), "Usuario");
        }

        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmSalas(), "Salas");
        }

        private void unidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmUnidade(), "Unidade");
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void fecharTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Msg.Confirmacao("Todos os formularios abertos serão finalizados !"))
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                    LogFile.RegistraLog("Todos Forms Finalizados.");
                }
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frmAb = new frmAbout();
            frmAb.ShowDialog();
        }

        private void endereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmEndereco(), "Endereço");
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmCidade(), "Cidade");
        }

        private void bairrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmBairro(), "Bairro");
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmEstado(), "Estado");
        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmPais(), "pais");
        }

        private void logradouroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmLogradouro(), "Logradouro");
        }

        private void professorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmProfessor(), "Professor");
        }

        private void nívelProfessorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmNivelProfessor(), "Nivel professor");
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmCurso(),"Curso");
        }

        private void matériasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrindo formulario "Filho" em principal
            LoadForm(new frmMateria(),"Materias");
        }

        protected void LoadForm(Form frm,string formulario)
        {
            Contagem.mdiQtd++;
            frm.MdiParent = this;
            frm.Show();
            LogFile.RegistraLog("Aberto cadastro de " + formulario + ".");
        }

    }
}
