using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.UTILS;
using BRA_SCHOOL.Opcoes;
using BRA_SCHOOL.MakeSql;

namespace BRA_SCHOOL.DAO
{
    class DaoPais
    {
        private DaoBase<EntPais> bd = new DaoBase<EntPais>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql() {

            Sql.Tabela = "tbPaises";
            Sql.TabelaPesquisa = "tbPaises";
            Sql.Campos = "DescricaoPais";
            Sql.ParametrosCampo = "@DescricaoPais";
            Sql.Chaves = "codPais";
            Sql.ParametrosChave = "@codPaises";
            Sql.CamposSaidaBusca = "codPais,DescricaoPais";
 
        }
         
        /// <summary>
        /// Lista de Paisess
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Lista de Paisess</returns>
        public List<EntPais> Listar()
        {
            List<EntPais> retPaises = new List<EntPais>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retPaises = bd.Busca(strSql);

            return retPaises;
        }

        /// <summary>
        /// Lista de Paisess pesquisados
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Lista de Paisess pesquisados</returns>
        public List<EntPais> Pesquisar(EntPais Paises)
        {
            List<EntPais> retPaises = new List<EntPais>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Paises.DescricaoPais != "")
            {
                strSql += " and DescricaoPais like @DescricaoPais";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoPais", "'%" + Paises.DescricaoPais + "%'");

            // realizando a busca
            retPaises = bd.Busca(strSql);

            return retPaises;
        }

        /// <summary>
        /// Grava dados do Paises
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Gravacao dos dados do Paises</returns>
        public bool Gravar(EntPais Paises)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();
                       
            // Passagem de parametros
            par.Add(new SqlParameter("@codPaises", Paises.CodPais));
            par.Add(new SqlParameter("@DescricaoPais", Paises.DescricaoPais));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbPaises", Paises.CodPais);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Paises
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntPais Paises)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoPais", Paises.DescricaoPais));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbPaises", Paises.CodPais);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Paises
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntPais Paises)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codPaises", Paises.CodPais));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbPaises", Paises.CodPais);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }   
    }
}
