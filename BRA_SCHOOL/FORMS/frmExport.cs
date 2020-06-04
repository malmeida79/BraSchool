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
    public partial class frmExport : Form
    {
        
        BuArquivo objBuArquivo = new BuArquivo();
        string caminho;

        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            
            Languages.LoadIdioma(this);

            List<EntArquivo> lstArquivo = new List<EntArquivo>();
            lstArquivo = objBuArquivo.Listar();

            cboArquivo.DataSource = lstArquivo;
            cboArquivo.DisplayMember = "DescricaoArquivo";
            cboArquivo.ValueMember = "CodArquivo";

            cboArquivo.SelectedIndex = -1;
            
        }


        private void btnSelecionar_Click(object sender, EventArgs e)
        {

            saveDiag.DefaultExt = "csv";
            saveDiag.Filter = "CSV Files (*.csv)|*.csv|XML Files (*.xml)|*.xml";
            saveDiag.InitialDirectory = @"C:\";
            saveDiag.Title = "Exportação de arquivos"; 

            saveDiag.ShowDialog();
            caminho = saveDiag.FileName;

            if (!string.IsNullOrEmpty(caminho))
            {
                btnExport.Enabled = true;
            }
            else {
                btnExport.Enabled = false;
            }

        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(caminho)&&cboArquivo.SelectedIndex >=0)
            {
                btnExport.Enabled = false;
            }
            else {
                Msg.MsgAlerta("Necessário selecionar um arquivo e pasta para exportação!");            
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Contagem.mdiQtd--;
        }
    }
}
