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
    class DaoSala
    {
        private DaoBase<EntSala> bd = new DaoBase<EntSala>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbSalas";
            Sql.TabelaPesquisa = "tbSalas sl inner join tbUnidades un on sl.codUnidade = un.codUnidade";
            Sql.Campos = "DescricaoSala,codUnidade";
            Sql.ParametrosCampo = "@DescricaoSala,@codUnidade";
            Sql.Chaves = "codSala";
            Sql.ParametrosChave = "@codSala";
            Sql.CamposSaidaBusca = @"codSala
                                    ,DescricaoSala
                                    ,sl.codUnidade
                                    ,DescricaoUnidade";
        }

        /// <summary>
        /// Lista de Salas
        /// </summary>
        /// <param name="Sala">Entidade Sala</param>
        /// <returns>Lista de Salas</returns>
        public List<EntSala> Listar()
        {
            List<EntSala> retSala = new List<EntSala>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retSala = bd.Busca(strSql);

            return retSala;
        }

        /// <summary>
        /// Lista de Salas pesquisados
        /// </summary>
        /// <param name="Sala">Entidade Sala</param>
        /// <returns>Lista de Salas pesquisados</returns>
        public List<EntSala> Pesquisar(EntSala Sala)
        {
            List<EntSala> retSala = new List<EntSala>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            // Passagem de parametros
            if (Sala.DescricaoSala != "")
            {
                strSql += " and DescricaoSala like @DescricaoSala";
                strSql = strSql.Replace("@DescricaoSala", "'%" + Sala.DescricaoSala + "%'");
            }

            // Passagem de parametros
            if (Sala.CodUnidade > 0)
            {
                strSql += " and sl.codunidade = @codUnidade";
                strSql = strSql.Replace("@codUnidade", Sala.CodUnidade.ToString());
            }

            // realizando a busca
            retSala = bd.Busca(strSql);

            return retSala;
        }

        /// <summary>
        /// Grava dados do Sala
        /// </summary>
        /// <param name="Sala">Entidade Sala</param>
        /// <returns>Gravacao dos dados do Sala</returns>
        public bool Gravar(EntSala Sala)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codSala", Sala.CodSala));
            par.Add(new SqlParameter("@DescricaoSala", Sala.DescricaoSala));
            par.Add(new SqlParameter("@codUnidade", Sala.CodUnidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbSala", Sala.CodSala);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Sala
        /// </summary>
        /// <param name="Sala">Entidade Sala</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntSala Sala)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoSala", Sala.DescricaoSala));
            par.Add(new SqlParameter("@codUnidade", Sala.CodUnidade));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbSala", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Sala
        /// </summary>
        /// <param name="Sala">Entidade Sala</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntSala Sala)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codSala", Sala.CodSala));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbSala", Sala.CodSala);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
