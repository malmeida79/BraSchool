using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using BRA_SCHOOL.FORMS;
using BRA_SCHOOL.Opcoes;

namespace BRA_SCHOOL.UTILS
{
    class Languages
    {
        public static ResourceManager rmGeral;
        public static ResourceManager rmMessage;
        public static CultureInfo ci;

        #region "Configuração do Idioma"

        public static void LoadIdioma(Form frm)
        {

            // TO DO: para rodar sera necessario chamar a rotina loadIdiomas e em seguida puxar pelo nome no rmGeral => 
            // rmGeral.GetString("<<chave dentro do resourse>>", ci);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            ci = Thread.CurrentThread.CurrentCulture;

            if (ci.Name == "pt-BR")
            {
                rmGeral = new ResourceManager("BRA_SCHOOL.RESOURCES.BR.ptBR", typeof(frmPrincipal).Assembly);
                rmMessage = new ResourceManager("BRA_SCHOOL.RESOURCES.BR.msgBR", typeof(frmPrincipal).Assembly);
            }
            else if (ci.Name == "es-ES")
            {
                rmGeral = new ResourceManager("BRA_SCHOOL.RESOURCES.BR.esES", typeof(frmPrincipal).Assembly);
                rmMessage = new ResourceManager("BRA_SCHOOL.RESOURCES.BR.msgES", typeof(frmPrincipal).Assembly);
            }
            else if (ci.Name == "en-US")
            {
                rmGeral = new ResourceManager("BRA_SCHOOL.RESOURCES.US.enUS", typeof(frmPrincipal).Assembly);
                rmMessage = new ResourceManager("BRA_SCHOOL.RESOURCES.US.msgUS", typeof(frmPrincipal).Assembly);
            }
            else
            {
                rmGeral = new ResourceManager("BRA_SCHOOL.RESOURCES.BR.ptBR", typeof(frmPrincipal).Assembly);
                rmMessage = new ResourceManager("BRA_SCHOOL.RESOURCES.BR.msgBR", typeof(frmPrincipal).Assembly);
            }

            //Altera o idioma da tela em questao.
            MudaIdioma(frm);

        }

        #endregion

        #region "Trata idioma"

        /// <summary>
        /// Altera o idioma dos controles para tela selecionada.
        /// </summary>
        /// <param name="frm"></param>
        protected static void MudaIdioma(Form frm)
        {

            if (frm.Tag != null)
            {
                if (!string.IsNullOrEmpty(frm.Tag.ToString()))
                {
                    frm.Text = rmGeral.GetString(frm.Tag.ToString(), ci);
                    frm.Text = frm.Text.Replace("[Qtd]", "[" + Contagem.mdiQtd.ToString() + "]");
                }
            }

            foreach (Control ctr in frm.Controls)
            {
                // group box deve ser tratado a parte, controle a controle dentro do mesmo
                if (ctr is MenuStrip)
                {
                    foreach (ToolStripItem nivel1 in ((MenuStrip)ctr).Items)
                    {
                        if (nivel1 is ToolStripMenuItem)
                        {
                            if (((ToolStripMenuItem)nivel1).HasDropDownItems)
                            {

                                TextoTraduzido(((ToolStripMenuItem)nivel1));

                                foreach (Object nivel2 in ((ToolStripMenuItem)nivel1).DropDownItems)
                                {
                                    if (nivel2 is ToolStripMenuItem)
                                    {
                                        if (((ToolStripMenuItem)nivel2).HasDropDownItems)
                                        {
                                            TextoTraduzido(((ToolStripMenuItem)nivel2));

                                            foreach (Object nivel3 in ((ToolStripMenuItem)nivel2).DropDownItems)
                                            {
                                                if (nivel3 is ToolStripMenuItem)
                                                {
                                                    if (((ToolStripMenuItem)nivel3).HasDropDownItems)
                                                    {
                                                        TextoTraduzido(((ToolStripMenuItem)nivel3));

                                                        foreach (Object nivel4 in ((ToolStripMenuItem)nivel3).DropDownItems)
                                                        {
                                                            if (nivel4 is ToolStripMenuItem)
                                                            {
                                                                TextoTraduzido(((ToolStripMenuItem)nivel4));
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        TextoTraduzido(((ToolStripMenuItem)nivel3));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            TextoTraduzido(((ToolStripMenuItem)nivel2));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                TextoTraduzido(((ToolStripMenuItem)nivel1));
                            }
                        }

                    }
                }
                else if (ctr is GroupBox)
                {
                    MudaIdiomaGrupo((ctr as GroupBox));
                }
                else
                {
                    // quando for do tipo checklistbox, cada item deverá ser tradado em separado
                    // dentro da lista
                    if (ctr is CheckedListBox)
                    {
                        foreach (ListControl item in (ctr as CheckedListBox).Items)
                        {
                            TextoTraduzido(item);
                        }
                    }
                    else
                    {
                        TextoTraduzido(ctr);
                    }
                }

            }

        }

        /// <summary>
        /// Quando controle do tipo groupbox, esse metodo configura os itens dentro do mesmo.
        /// </summary>
        /// <param name="grupo">Grupo a ser tratado o idioma.</param>
        protected static void MudaIdiomaGrupo(GroupBox grupo)
        {
            foreach (Control ctr in grupo.Controls)
            {
                // quando for do tipo checklistbox, cada item deverá ser tradado em separado
                // dentro da lista
                if (ctr is CheckedListBox)
                {
                    foreach (ListControl item in (ctr as CheckedListBox).Items)
                    {
                        TextoTraduzido(item);
                    }
                }
                else
                {
                    TextoTraduzido(ctr);
                }
            }
        }

        #endregion

        #region "Preenche Tela"
        /// <summary>
        /// Troca o texto pelo texto traduzido vindo do resource
        /// </summary>
        /// <param name="menuItem"></param>
        protected static void TextoTraduzido(ToolStripMenuItem menuItem)
        {

            if (menuItem.Tag != null)
            {
                if (!string.IsNullOrEmpty(menuItem.Tag.ToString()))
                {
                    menuItem.Text = rmGeral.GetString(menuItem.Tag.ToString(), ci);
                }
            }

        }

        /// <summary>
        /// Troca o texto pelo texto traduzido vindo do resource
        /// </summary>
        /// <param name="campo"></param>
        protected static void TextoTraduzido(Control campo)
        {
            if (campo.Tag != null)
            {
                if (!string.IsNullOrEmpty(campo.Tag.ToString()))
                {
                    campo.Text = rmGeral.GetString(campo.Tag.ToString(), ci);
                }
            }
        }

        /// <summary>
        /// Troca o texto pelo texto traduzido vindo do resource
        /// </summary>
        /// <param name="item"></param>
        protected static void TextoTraduzido(ListControl item)
        {
            if (item.Tag != null)
            {
                if (!string.IsNullOrEmpty(item.Tag.ToString()))
                {
                    item.Text = rmGeral.GetString(item.Tag.ToString(), ci);
                }
            }
        }

        #endregion

    }
}
