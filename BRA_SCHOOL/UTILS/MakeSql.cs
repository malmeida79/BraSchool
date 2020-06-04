using System.Linq;
using BRA_SCHOOL.UTILS;

namespace BRA_SCHOOL.MakeSql
{
    /// <summary>
    /// Classe para construção de comandos SQL
    /// </summary>
    public  class Sql
    {
        protected static string[] arrCampos;
        protected static string[] arrParametrosCampo;
        protected static string[] arrChaves;
        protected static string[] arrParametrosChave;
        protected static string[] arrBusca;
        protected static string[] arrParametrosBusca;

        public static string Tabela;
        public static string TabelaPesquisa;
        public static string Campos;
        public static string ParametrosCampo;
        public static string Chaves;
        public static string ParametrosChave;
        public static string CamposSaidaBusca;
        public static string Busca;
        public static string ParametrosBusca;        

        protected static void carregaValores()
        {
            if (!string.IsNullOrEmpty(Campos))
            {
                arrCampos = Campos.Split(',');
            }

            if (!string.IsNullOrEmpty(ParametrosCampo))
            {
                arrParametrosCampo = ParametrosCampo.Split(',');
            }

            if (!string.IsNullOrEmpty(Chaves))
            {
                arrChaves = Chaves.Split(',');
            }

            if (!string.IsNullOrEmpty(ParametrosChave))
            {
                arrParametrosChave = ParametrosChave.Split(',');
            }

            if (!string.IsNullOrEmpty(Busca))
            {
                arrBusca = Busca.Split(',');
            }

            if (!string.IsNullOrEmpty(ParametrosBusca))
            {
                arrParametrosBusca = ParametrosBusca.Split(',');
            }
        }

        /// <summary>
        /// Constroi SQl para Insert em banco de dados
        /// </summary>
        /// <returns></returns>
        public static string CriarInsert()
        {

            string retorno;

            retorno = "insert into " + Tabela + "(" + Campos + ") values (" + ParametrosCampo + ")";

            return retorno;

        }

        /// <summary>
        /// Constroi SQL para Delete em banco de dados
        /// </summary>
        /// <returns></returns>
        public static string CriarDelete()
        {

            string retorno;
            int i = 0;

            carregaValores();

            retorno = "Delete from " + Tabela + " where 1 = 1 ";

            if (arrChaves.Count() > 0)
            {
                while (i < arrChaves.Count())
                {
                    retorno += " and " + arrChaves[i] + "=" + arrParametrosChave[i];
                    i++;
                }
            }
            else
            {
                retorno = "Erro: Comando delete sem condição de exclusão.";
                LogFile.RegistraLog(retorno);
            }

            return retorno;

        }

        /// <summary>
        /// Constroi SQL para Update em Banco de dados
        /// </summary>
        /// <returns></returns> 
        public static string CriarUpdate()
        {

            string retorno;
            int i = 0;

            carregaValores();

            retorno = "Update " + Tabela + " set ";

            if (arrCampos.Count() > 0)
            {
                while (i < arrCampos.Count())
                {
                    retorno += arrCampos[i] + "=" + arrParametrosCampo[i] + ",";
                    i++;
                }

                retorno += "*";

                retorno = retorno.Replace(",*", "");

                i = 0;

                retorno += " where 1 = 1 ";

                if (arrChaves.Count() > 0)
                {
                    while (i < arrChaves.Count())
                    {
                        retorno += " and " + arrChaves[i] + "=" + arrParametrosChave[i];
                        i++;
                    }
                }
                else
                {
                    retorno = "Erro: Comando Update sem condição de atualização.";
                    LogFile.RegistraLog(retorno);
                }
            }
            else
            {
                retorno = "Erro: Comando Update sem campos para atualização.";
                LogFile.RegistraLog(retorno);
            }

            return retorno;

        }

        /// <summary>
        ///  Constroi SQL para Select em Banco de dados
        /// </summary>
        /// <returns></returns>
        public static string CriarSelect()
        {

            string retorno;
            int i = 0;

            carregaValores();

            retorno = "Select " + CamposSaidaBusca + " from "+ TabelaPesquisa + " where 1 = 1 ";

            if (!string.IsNullOrEmpty(Busca))
            {
                if (arrBusca.Count() > 0)
                {
                    while (i < arrBusca.Count())
                    {
                        retorno += " and " + arrBusca[i] + "=" + arrParametrosBusca[i];
                        i++;
                    }
                }
            }

            return retorno;
        }
    }
}
