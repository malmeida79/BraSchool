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
    class DaoBairro
    {
        private DaoBase<EntBairro> bd = new DaoBase<EntBairro>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbBairros";
            Sql.TabelaPesquisa = @"tbBairros br 
                                   inner join tbCidades cd on br.codCidade = cd.codCidade
                                   inner join tbEstados es on es.codEstado = cd.codEstado
                                   inner join tbPaises p on p.codPais = es.CodPais
                                 ";

            Sql.Campos = "DescricaoBairro,codCidade";
            Sql.ParametrosCampo = "@DescricaoBairro,@codCidade";
            Sql.Chaves = "codBairro";
            Sql.ParametrosChave = "@codBairro";
            Sql.CamposSaidaBusca = @"codBairro
                                    ,DescricaoBairro
                                    ,br.codCidade
                                    ,DescricaoCidade
                                    ,cd.codEstado
                                    ,DescricaoEstado
                                    ,p.codPais
                                    ,DescricaoPais";
        }

        /// <summary>
        /// Lista de Bairros
        /// </summary>
        /// <param name="Bairro">Entidade Bairro</param>
        /// <returns>Lista de Bairros</returns>
        public List<EntBairro> Listar()
        {
            List<EntBairro> retBairro = new List<EntBairro>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retBairro = bd.Busca(strSql);

            return retBairro;
        }

        /// <summary>
        /// Lista de Bairros pesquisados
        /// </summary>
        /// <param name="Bairro">Entidade Bairro</param>
        /// <returns>Lista de Bairros pesquisados</returns>
        public List<EntBairro> Pesquisar(EntBairro Bairro)
        {
            List<EntBairro> retBairro = new List<EntBairro>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            // Passagem de parametros
            if (Bairro.DescricaoBairro != "")
            {
                strSql += " and DescricaoBairro like @DescricaoBairro";
                strSql = strSql.Replace("@DescricaoBairro", "'%" + Bairro.DescricaoBairro + "%'");
            }

            // Passagem de parametros
            if (Bairro.CodCidade > 0)
            {
                strSql += " and br.codCidade = @codCidade";
                strSql = strSql.Replace("@codCidade", Bairro.CodCidade.ToString());
            }

            // realizando a busca
            retBairro = bd.Busca(strSql);

            return retBairro;
        }

        /// <summary>
        /// Grava dados do Bairro
        /// </summary>
        /// <param name="Bairro">Entidade Bairro</param>
        /// <returns>Gravacao dos dados do Bairro</returns>
        public bool Gravar(EntBairro Bairro)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codBairro", Bairro.CodBairro));
            par.Add(new SqlParameter("@DescricaoBairro", Bairro.DescricaoBairro));
            par.Add(new SqlParameter("@codCidade", Bairro.CodCidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbBairro", Bairro.CodBairro);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Bairro
        /// </summary>
        /// <param name="Bairro">Entidade Bairro</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntBairro Bairro)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoBairro", Bairro.DescricaoBairro));
            par.Add(new SqlParameter("@codCidade", Bairro.CodCidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbBairro", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Bairro
        /// </summary>
        /// <param name="Bairro">Entidade Bairro</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntBairro Bairro)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codBairro", Bairro.CodBairro));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbBairro", Bairro.CodBairro);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
