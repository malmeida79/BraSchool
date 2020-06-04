using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRA_SCHOOL.Opcoes
{

    #region "Usuario Logado"
    public static class Logado
    {

        public static int logadoCod = 1;
        public static string logadoLogin = "Marcos";        
        public static int logadoTentativas = 0;
        public static bool logadoBloqueado = false;

    }
    #endregion

    #region "Controle MDI"
    public static class Contagem
    {
        public static int mdiQtd = 0;
    }
    #endregion

    #region "Mensagens"

    public static class Msg
    {
        /// <summary>
        /// Mensagem de alerta
        /// </summary>
        /// <param name="texto">Texto para mensagem</param>
        public static void MsgAlerta(string texto)
        {
            MessageBox.Show(texto, ":: Aviso ::", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// Mensagem de erro
        /// </summary>
        /// <param name="texto">Texto para mensagem</param>
        public static void MsgErro(string texto)
        {
            MessageBox.Show(texto, ":: Erro ::", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Teste para confirmacao do usuario
        /// </summary>
        /// <param name="texto">Texto para mensagem</param>
        /// <returns>retorno verdadeiro se confirmado ou falso para nao confirmado</returns>
        public static bool Confirmacao(string texto)
        {
            DialogResult teste;
            bool retorno;

            teste = MessageBox.Show(texto, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (teste == DialogResult.Yes)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

    }
    #endregion

    #region "Limpeza"

    public static class Limpeza
    {
        /// <summary>
        /// Limpeza de controle no formulario indicado
        /// </summary>
        /// <param name="frm">Formulario indicado</param>
        public static void Controles(Form frm)
        {

            foreach (Control ctr in frm.Controls)
            {

                if (ctr is TextBox)
                {
                    (ctr as TextBox).Text = "";
                }

                if (ctr is GroupBox)
                {
                    LimpaGrupoControles((ctr as GroupBox));
                }

                if (ctr is RadioButton)
                {
                    (ctr as RadioButton).Checked = false;
                }

                if (ctr is CheckBox)
                {
                    (ctr as CheckBox).Checked = false;
                }

                if (ctr is ComboBox)
                {
                    (ctr as ComboBox).SelectedIndex = -1;
                }

                if (ctr is ListBox)
                {
                    (ctr as ListBox).SelectedIndex = -1;
                }

                if (ctr is CheckedListBox)
                {
                    foreach (ListControl item in (ctr as CheckedListBox).Items)
                    {
                        item.SelectedIndex = -1;
                    }
                }

                if (ctr is NumericUpDown)
                {
                    (ctr as NumericUpDown).Value = 0;
                }

                if (ctr is DataGridView)
                {
                    (ctr as DataGridView).DataSource = "";
                }

            }

        }

        private static void LimpaGrupoControles(GroupBox grupo)
        {

            foreach (Control ctr in grupo.Controls)
            {

                if (ctr is TextBox)
                {
                    (ctr as TextBox).Text = "";
                }

                if (ctr is RadioButton)
                {
                    (ctr as RadioButton).Checked = false;
                }

                if (ctr is CheckBox)
                {
                    (ctr as CheckBox).Checked = false;
                }

                if (ctr is ComboBox)
                {
                    (ctr as ComboBox).SelectedIndex = -1;
                }

                if (ctr is ListBox)
                {
                    (ctr as ListBox).SelectedIndex = -1;
                }

                if (ctr is CheckedListBox)
                {
                    foreach (ListControl item in (ctr as CheckedListBox).Items)
                    {
                        item.SelectedIndex = -1;
                    }
                }

                if (ctr is NumericUpDown)
                {
                    (ctr as NumericUpDown).Value = 0;
                }

                if (ctr is DataGridView)
                {
                    (ctr as DataGridView).DataSource = "";
                }

            }

        }

    }

    #endregion

    #region "Validacoes"

    public static class Valida
    {

        /// <summary>
        /// Compara dois valores
        /// </summary>
        /// <param name="valor1">informacao a ser comparada</param>
        /// <param name="valor2">informacao a ser comparada</param>
        /// <returns>True caso iguais e false caso nao</returns>
        public static bool ComparaValores(string valor1, string valor2)
        {

            bool retorno = false;

            if (valor1 == valor2)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Valida se o campo esta preenchido
        /// </summary>
        /// <param name="valor">Valor a ser validado</param>
        /// <param name="quantidadeMinima">Se informado, determina a qua
        /// ntidade minima de caracteres no campo.</param>
        /// <returns>True caso validado ou false caso nao</returns>
        public static bool EstaPreenchido(string valor, int quantidadeMinima = 0)
        {
            bool retorno = false;

            if (quantidadeMinima == 0)
            {
                if (valor.Length > 0)
                {
                    retorno = true;
                }
            }
            else
            {
                if (valor.Length >= quantidadeMinima)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Verifica se valor é numerico
        /// </summary>
        /// <param name="valor">Valor a ser verificado</param>
        /// <returns>True caso numero e false caso nao</returns>
        public static bool Numerico(string valor)
        {

            int result;
            bool retorno = false;

            if (!int.TryParse(valor, out result))
            {
                retorno = true;
            }

            return retorno;

        }

        /// <summary>
        /// Valida se existe item selecionado
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool SelecionadoItem(int index)
        {

            bool retorno = false;

            if (index >= 0)
            {
                retorno = true;
            }

            return retorno;

        }

        /// <summary>
        /// Validação para horario inicial menor que final
        /// </summary>
        /// <param name="horaInicio">Horario inciial</param>
        /// <param name="horaFim">Horario Final</param>
        /// <returns>True caso verdadeiro</returns>
        public static bool ValidaHoraInicialMenorQueFinal(string horaInicio, string horaFim)
        {

            bool retorno = false;
            DateTime hrIni = Convert.ToDateTime(horaInicio);
            DateTime hrFim = Convert.ToDateTime(horaFim);

            if (hrIni < hrFim)
            {
                retorno = true;
            }

            return retorno;

        }

    }

    #endregion

}
