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
    class DaoGrupo
    {
        private DaoBase<EntGrupo> bd = new DaoBase<EntGrupo>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {
            Sql.Tabela = "tbGrupos";
            Sql.TabelaPesquisa = "tbGrupos";
            Sql.Campos = "DescricaoGrupo";
            Sql.ParametrosCampo = "@DescricaoGrupo";
            Sql.Chaves = "codGrupo";
            Sql.ParametrosChave = "@codGrupos";
            Sql.CamposSaidaBusca = @"codGrupo,DescricaoGrupo";
        }

        /// <summary>
        /// Lista de Gruposs
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Lista de Gruposs</returns>
        public List<EntGrupo> Listar()
        {
            List<EntGrupo> retGrupos = new List<EntGrupo>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retGrupos = bd.Busca(strSql);

            return retGrupos;
        }

        /// <summary>
        /// Lista de Gruposs pesquisados
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Lista de Gruposs pesquisados</returns>
        public List<EntGrupo> Pesquisar(EntGrupo Grupos)
        {
            List<EntGrupo> retGrupos = new List<EntGrupo>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Grupos.DescricaoGrupo != "")
            {
                strSql += " and DescricaoGrupo like @DescricaoGrupo";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoGrupo", "'%" + Grupos.DescricaoGrupo + "%'");

            // realizando a busca
            retGrupos = bd.Busca(strSql);

            return retGrupos;
        }

        /// <summary>
        /// Grava dados do Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Gravacao dos dados do Grupos</returns>
        public bool Gravar(EntGrupo Grupos)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codGrupos", Grupos.CodGrupo));
            par.Add(new SqlParameter("@DescricaoGrupo", Grupos.DescricaoGrupo));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbGrupos", Grupos.CodGrupo);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntGrupo Grupos)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoGrupo", Grupos.DescricaoGrupo));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbGrupos", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntGrupo Grupos)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codGrupos", Grupos.CodGrupo));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbGrupos", Grupos.CodGrupo);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
