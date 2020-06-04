using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using BRA_SCHOOL.FORMS;

namespace BRA_SCHOOL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string idioma = Properties.Settings.Default.Idioma;

            // Configuração de idioma do sistema
            Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma);

            /*
            // Inicializacao completa
            // abrindo a tela de splash
            frmSplash splash = new frmSplash();
            splash.ShowDialog();

            // chamando tela de login
            frmLogin login = new frmLogin();

            // se login ok, processar frmPrincipal
            if (login.ShowDialog() == DialogResult.OK)
            {
                // abrindo a aplicacao
                Application.Run(new frmPrincipal());
            }
            else {
                // caso nao, finalizar aplicacao
                Application.Exit();
            }*/

            // Inicializacao Opcional com formEspecifico
            Application.Run(new frmExport());
        }
    }
}
