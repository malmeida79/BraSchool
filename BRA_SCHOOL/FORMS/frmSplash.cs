using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRA_SCHOOL.FORMS
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            lblVersao.Text = "Versão:" + Application.ProductVersion;
        }

        private void frmSplash_Shown(object sender, EventArgs e)
        {
            //Método Shown do Form2
            for (int x = 0; x < 100; x++)
            {
                pbBar.Value++;
                Application.DoEvents(); //Para não travar a tela
                System.Threading.Thread.Sleep(90);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
