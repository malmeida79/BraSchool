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
    class DaoFuncionalidade
    {
        private DaoBase<EntFuncionalidade> bd = new DaoBase<EntFuncionalidade>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {
            Sql.Tabela = "tbFuncionalidades";
            Sql.TabelaPesquisa = "tbFuncionalidades";
            Sql.Campos = "DescricaoFuncionalidade";
            Sql.ParametrosCampo = "@DescricaoFuncionalidade";
            Sql.Chaves = "codFuncionalidade";
            Sql.ParametrosChave = "@codFuncionalidades";
            Sql.CamposSaidaBusca = @"codFuncionalidade,DescricaoFuncionalidade";
        }

        /// <summary>
        /// Lista de Funcionalidadess
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Lista de Funcionalidadess</returns>
        public List<EntFuncionalidade> Listar()
        {
            List<EntFuncionalidade> retFuncionalidades = new List<EntFuncionalidade>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retFuncionalidades = bd.Busca(strSql);

            return retFuncionalidades;
        }

        /// <summary>
        /// Lista de Funcionalidadess pesquisados
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Lista de Funcionalidadess pesquisados</returns>
        public List<EntFuncionalidade> Pesquisar(EntFuncionalidade Funcionalidades)
        {
            List<EntFuncionalidade> retFuncionalidades = new List<EntFuncionalidade>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Funcionalidades.DescricaoFuncionalidade != "")
            {
                strSql += " and DescricaoFuncionalidade like @DescricaoFuncionalidade";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoFuncionalidade", "'%" + Funcionalidades.DescricaoFuncionalidade + "%'");

            // realizando a busca
            retFuncionalidades = bd.Busca(strSql);

            return retFuncionalidades;
        }

        /// <summary>
        /// Grava dados do Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Gravacao dos dados do Funcionalidades</returns>
        public bool Gravar(EntFuncionalidade Funcionalidades)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codFuncionalidades", Funcionalidades.CodFuncionalidade));
            par.Add(new SqlParameter("@DescricaoFuncionalidade", Funcionalidades.DescricaoFuncionalidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbFuncionalidades", Funcionalidades.CodFuncionalidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntFuncionalidade Funcionalidades)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoFuncionalidade", Funcionalidades.DescricaoFuncionalidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbFuncionalidades", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntFuncionalidade Funcionalidades)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codFuncionalidades", Funcionalidades.CodFuncionalidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbFuncionalidades", Funcionalidades.CodFuncionalidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
