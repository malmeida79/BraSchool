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
    class DaoCidade
    {
        private DaoBase<EntCidade> bd = new DaoBase<EntCidade>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbCidades";
            Sql.TabelaPesquisa = @"tbCidades cd 
                                   inner join tbEstados es on cd.codEstado = es.codEstado
                                   inner join tbPaises p on p.codPais = es.codPais";

            Sql.Campos = "DescricaoCidade,codEstado";
            Sql.ParametrosCampo = "@DescricaoCidade,@codEstado";
            Sql.Chaves = "codCidade";
            Sql.ParametrosChave = "@codCidade";
            Sql.CamposSaidaBusca = @"codCidade
                                    ,DescricaoCidade
                                    ,cd.codEstado
                                    ,DescricaoEstado
                                    ,es.codPais
                                    ,DescricaoPais";
        }

        /// <summary>
        /// Lista de Cidades
        /// </summary>
        /// <param name="Cidade">Entidade Cidade</param>
        /// <returns>Lista de Cidades</returns>
        public List<EntCidade> Listar()
        {
            List<EntCidade> retCidade = new List<EntCidade>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retCidade = bd.Busca(strSql);

            return retCidade;
        }

        /// <summary>
        /// Lista de Cidades pesquisados
        /// </summary>
        /// <param name="Cidade">Entidade Cidade</param>
        /// <returns>Lista de Cidades pesquisados</returns>
        public List<EntCidade> Pesquisar(EntCidade Cidade)
        {
            List<EntCidade> retCidade = new List<EntCidade>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            // Passagem de parametros
            if (Cidade.DescricaoCidade != "")
            {
                strSql += " and DescricaoCidade like @DescricaoCidade";
                strSql = strSql.Replace("@DescricaoCidade", "'%" + Cidade.DescricaoCidade + "%'");
            }

            // Passagem de parametros
            if (Cidade.CodEstado > 0)
            {
                strSql += " and cd.codEstado = @codEstado";
                strSql = strSql.Replace("@codEstado", Cidade.CodEstado.ToString());
            }

            strSql += "order by DescricaoCidade,DescricaoEstado,DescricaoPais";

            // realizando a busca
            retCidade = bd.Busca(strSql);

            return retCidade;
        }

        /// <summary>
        /// Grava dados do Cidade
        /// </summary>
        /// <param name="Cidade">Entidade Cidade</param>
        /// <returns>Gravacao dos dados do Cidade</returns>
        public bool Gravar(EntCidade Cidade)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codCidade", Cidade.CodCidade));
            par.Add(new SqlParameter("@DescricaoCidade", Cidade.DescricaoCidade));
            par.Add(new SqlParameter("@codEstado", Cidade.CodEstado));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbCidade", Cidade.CodCidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Cidade
        /// </summary>
        /// <param name="Cidade">Entidade Cidade</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntCidade Cidade)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoCidade", Cidade.DescricaoCidade));
            par.Add(new SqlParameter("@codEstado", Cidade.CodEstado));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbCidade", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Cidade
        /// </summary>
        /// <param name="Cidade">Entidade Cidade</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntCidade Cidade)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codCidade", Cidade.CodCidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbCidade", Cidade.CodCidade);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
