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
    class DaoUnidade
    {
        private DaoBase<EntUnidade> bd = new DaoBase<EntUnidade>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbUnidades";
            Sql.TabelaPesquisa = "tbUnidades";
            Sql.Campos = "DescricaoUnidade";
            Sql.ParametrosCampo = "@DescricaoUnidade";
            Sql.Chaves = "CodUnidade";
            Sql.ParametrosChave = "@codUnidade";
            Sql.CamposSaidaBusca = @"codunidade
                                     ,DescricaoUnidade";
        }

        /// <summary>
        /// Lista de Unidades
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Lista de Unidades</returns>
        public List<EntUnidade> Listar()
        {
            List<EntUnidade> retUnidade = new List<EntUnidade>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retUnidade = bd.Busca(strSql);

            return retUnidade;
        }

        /// <summary>
        /// Lista de Unidades pesquisados
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Lista de Unidades pesquisados</returns>
        public List<EntUnidade> Pesquisar(EntUnidade Unidade)
        {
            List<EntUnidade> retUnidade = new List<EntUnidade>();

            string strSql;

            ConfiguraSql();

            strSql = Sql.CriarSelect();

            if (Unidade.DescricaoUnidade != "")
            {
                strSql += " and DescricaoUnidade like @DescricaoUnidade";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoUnidade", "'%" + Unidade.DescricaoUnidade + "%'");

            // realizando a busca
            retUnidade = bd.Busca(strSql);

            return retUnidade;
        }

        /// <summary>
        /// Grava dados do Unidade
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Gravacao dos dados do Unidade</returns>
        public bool Gravar(EntUnidade Unidade)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codUnidade", Unidade.CodUnidade));
            par.Add(new SqlParameter("@DescricaoUnidade", Unidade.DescricaoUnidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbUnidades", Unidade.CodUnidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Unidade
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntUnidade Unidade)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoUnidade", Unidade.DescricaoUnidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbUnidades", Unidade.CodUnidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Unidade
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntUnidade Unidade)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codUnidade", Unidade.CodUnidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbCursos", Unidade.CodUnidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }   
    }
}
