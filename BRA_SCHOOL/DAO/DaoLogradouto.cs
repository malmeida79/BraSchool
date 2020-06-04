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
    class DaoLogradouro
    {
        private DaoBase<EntLogradouro> bd = new DaoBase<EntLogradouro>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql() {

            Sql.Tabela = "tbLogradouro";
            Sql.TabelaPesquisa = "tbLogradouro";
            Sql.Campos = "DescricaoLogradouro";
            Sql.ParametrosCampo = "@DescricaoLogradouro";
            Sql.Chaves = "codLogradouro";
            Sql.ParametrosChave = "@codLogradouro";
            Sql.CamposSaidaBusca = "codLogradouro,DescricaoLogradouro";
 
        }
         
        /// <summary>
        /// Lista de Logradouros
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Lista de Logradouros</returns>
        public List<EntLogradouro> Listar()
        {
            List<EntLogradouro> retLogradouro = new List<EntLogradouro>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retLogradouro = bd.Busca(strSql);

            return retLogradouro;
        }

        /// <summary>
        /// Lista de Logradouros pesquisados
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Lista de Logradouros pesquisados</returns>
        public List<EntLogradouro> Pesquisar(EntLogradouro Logradouro)
        {
            List<EntLogradouro> retLogradouro = new List<EntLogradouro>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Logradouro.DescricaoLogradouro != "")
            {
                strSql += " and DescricaoLogradouro like @DescricaoLogradouro";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoLogradouro", "'%" + Logradouro.DescricaoLogradouro + "%'");

            // realizando a busca
            retLogradouro = bd.Busca(strSql);

            return retLogradouro;
        }

        /// <summary>
        /// Grava dados do Logradouro
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Gravacao dos dados do Logradouro</returns>
        public bool Gravar(EntLogradouro Logradouro)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();
                       
            // Passagem de parametros
            par.Add(new SqlParameter("@codLogradouro", Logradouro.CodLogradouro));
            par.Add(new SqlParameter("@DescricaoLogradouro", Logradouro.DescricaoLogradouro));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbLogradouro", Logradouro.CodLogradouro);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Logradouro
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntLogradouro Logradouro)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoLogradouro", Logradouro.DescricaoLogradouro));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbLogradouro", Logradouro.CodLogradouro);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Logradouro
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntLogradouro Logradouro)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codLogradouro", Logradouro.CodLogradouro));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbLogradouro", Logradouro.CodLogradouro);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }   
    }
}
