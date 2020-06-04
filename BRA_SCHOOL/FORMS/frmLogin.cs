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
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.BU;
using BRA_SCHOOL.Opcoes;
using BRA_SCHOOL.UTILS;

namespace BRA_SCHOOL.FORMS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();        
        }

        #region "Tela de Login"

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Instancia dos objetos
            EntUsuario usuario = new EntUsuario();
            BuUsuario objbu = new BuUsuario();

            // Carregando dados para o Login
            usuario.LoginUsuario = txtLogin.Text;
            usuario.SenhaUsuario = txtSenha.Text;

            // Executando login
            if (objbu.Logar(usuario))
            {
                // como o aplicativo e conduzido pelo program.cs
                // indicando que a resposta é OK o sistema
                // abre a aplicacao
                if (!Logado.logadoBloqueado)
                {
                    DialogResult = DialogResult.OK;
                    LogFile.RegistraLog("Usuario inicia login.");
                }
                else {
                    DialogResult = DialogResult.Cancel;
                    LogFile.RegistraLog("Usuario esta bloqueado.");
                    Msg.MsgAlerta("Este usuário esta bloqueado.");
                }
            }
            else
            {
                // cada vez que login falha adiciona tentativa
                Logado.logadoTentativas++;

                if (Logado.logadoTentativas == 3)
                {

                    // notifica o usuario
                    Msg.MsgErro("Tentativas Esgotadas, usuário bloqueado !");

                    //Bloqueia usuario
                    objbu.Bloqueia(usuario);

                    // zerando as tentativas
                    Logado.logadoTentativas = 0;
                }
                else
                {
                    Msg.MsgErro("Login não autorizado!");
                }

                txtLogin.Text = "";
                txtSenha.Text = "";
                txtLogin.Focus();
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            if (Msg.Confirmacao("Deseja realmente sair?"))
            {
                // como o aplicativo e conduzido pelo program.cs
                // indicando que a resposta é cancel o sistema
                // sai sem abrir a aplicacao
                DialogResult = DialogResult.Cancel;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
            Languages.LoadIdioma(this);
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            txtLogin.Text = txtLogin.Text.ToUpper();
        }

        #endregion

    }
}
