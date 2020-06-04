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
    class DaoEndereco
    {
        private DaoBase<EntEndereco> bd = new DaoBase<EntEndereco>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbEnderecos";
            Sql.TabelaPesquisa = @"tbEnderecos br 
                                   inner join tbCidades cd on br.codCidade = cd.codCidade
                                   inner join tbEstados es on es.codEstado = cd.codEstado
                                   inner join tbPaises p on p.codPais = es.CodPais
                                 ";

            Sql.Campos = "DescricaoEndereco,codCidade";
            Sql.ParametrosCampo = "@DescricaoEndereco,@codCidade";
            Sql.Chaves = "codEndereco";
            Sql.ParametrosChave = "@codEndereco";
            Sql.CamposSaidaBusca = @"codEndereco
                                    ,DescricaoEndereco
                                    ,br.codCidade
                                    ,DescricaoCidade
                                    ,cd.codEstado
                                    ,DescricaoEstado
                                    ,p.codPais
                                    ,DescricaoPais";
        }

        /// <summary>
        /// Lista de Enderecos
        /// </summary>
        /// <param name="Endereco">Entidade Endereco</param>
        /// <returns>Lista de Enderecos</returns>
        public List<EntEndereco> Listar()
        {
            List<EntEndereco> retEndereco = new List<EntEndereco>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retEndereco = bd.Busca(strSql);

            return retEndereco;
        }

        /// <summary>
        /// Lista de Enderecos pesquisados
        /// </summary>
        /// <param name="Endereco">Entidade Endereco</param>
        /// <returns>Lista de Enderecos pesquisados</returns>
        public List<EntEndereco> Pesquisar(EntEndereco Endereco)
        {
            List<EntEndereco> retEndereco = new List<EntEndereco>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            // Passagem de parametros
            if (Endereco.DescricaoEndereco != "")
            {
                strSql += " and DescricaoEndereco like @DescricaoEndereco";
                strSql = strSql.Replace("@DescricaoEndereco", "'%" + Endereco.DescricaoEndereco + "%'");
            }

            // Passagem de parametros
            if (Endereco.CodCidade > 0)
            {
                strSql += " and br.codCidade = @codCidade";
                strSql = strSql.Replace("@codCidade", Endereco.CodCidade.ToString());
            }

            // realizando a busca
            retEndereco = bd.Busca(strSql);

            return retEndereco;
        }

        /// <summary>
        /// Grava dados do Endereco
        /// </summary>
        /// <param name="Endereco">Entidade Endereco</param>
        /// <returns>Gravacao dos dados do Endereco</returns>
        public bool Gravar(EntEndereco Endereco)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codEndereco", Endereco.CodEndereco));
            par.Add(new SqlParameter("@DescricaoEndereco", Endereco.DescricaoEndereco));
            par.Add(new SqlParameter("@codCidade", Endereco.CodCidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbEndereco", Endereco.CodEndereco);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Endereco
        /// </summary>
        /// <param name="Endereco">Entidade Endereco</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntEndereco Endereco)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoEndereco", Endereco.DescricaoEndereco));
            par.Add(new SqlParameter("@codCidade", Endereco.CodCidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbEndereco", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Endereco
        /// </summary>
        /// <param name="Endereco">Entidade Endereco</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntEndereco Endereco)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codEndereco", Endereco.CodEndereco));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbEndereco", Endereco.CodEndereco);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
