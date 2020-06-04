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
    class DaoEstado
    {
        private DaoBase<EntEstado> bd = new DaoBase<EntEstado>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbEstados";
            Sql.TabelaPesquisa = "tbEstados es inner join tbPaises p on es.codPais = p.codPais";
            Sql.Campos = "DescricaoEstado,codPais";
            Sql.ParametrosCampo = "@DescricaoEstado,@codPais";
            Sql.Chaves = "codEstado";
            Sql.ParametrosChave = "@codEstado";
            Sql.CamposSaidaBusca = @"codEstado
                                    ,DescricaoEstado
                                    ,es.codPais
                                    ,DescricaoPais";
        }

        /// <summary>
        /// Lista de Estados
        /// </summary>
        /// <param name="Estado">Entidade Estado</param>
        /// <returns>Lista de Estados</returns>
        public List<EntEstado> Listar()
        {
            List<EntEstado> retEstado = new List<EntEstado>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retEstado = bd.Busca(strSql);

            return retEstado;
        }

        /// <summary>
        /// Lista de Estados pesquisados
        /// </summary>
        /// <param name="Estado">Entidade Estado</param>
        /// <returns>Lista de Estados pesquisados</returns>
        public List<EntEstado> Pesquisar(EntEstado Estado)
        {
            List<EntEstado> retEstado = new List<EntEstado>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            // Passagem de parametros
            if (Estado.DescricaoEstado != "")
            {
                strSql += " and DescricaoEstado like @DescricaoEstado";
                strSql = strSql.Replace("@DescricaoEstado", "'%" + Estado.DescricaoEstado + "%'");
            }

            // Passagem de parametros
            if (Estado.CodPais > 0)
            {
                strSql += " and es.codPais = @codPais";
                strSql = strSql.Replace("@codPais", Estado.CodPais.ToString());
            }

            strSql += " order by descricaoEstado";

            // realizando a busca
            retEstado = bd.Busca(strSql);

            return retEstado;
        }

        /// <summary>
        /// Grava dados do Estado
        /// </summary>
        /// <param name="Estado">Entidade Estado</param>
        /// <returns>Gravacao dos dados do Estado</returns>
        public bool Gravar(EntEstado Estado)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codEstado", Estado.CodEstado));
            par.Add(new SqlParameter("@DescricaoEstado", Estado.DescricaoEstado));
            par.Add(new SqlParameter("@codPais", Estado.CodPais));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbEstado", Estado.CodEstado);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Estado
        /// </summary>
        /// <param name="Estado">Entidade Estado</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntEstado Estado)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoEstado", Estado.DescricaoEstado));
            par.Add(new SqlParameter("@codPais", Estado.CodPais));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbEstado", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Estado
        /// </summary>
        /// <param name="Estado">Entidade Estado</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntEstado Estado)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codEstado", Estado.CodEstado));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbEstado", Estado.CodEstado);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
