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
    class DaoMateria
    {
        private DaoBase<EntMateria> bd = new DaoBase<EntMateria>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbMaterias";
            Sql.TabelaPesquisa = "tbMaterias";
            Sql.Campos = "DescricaoMateria";
            Sql.ParametrosCampo = "@DescricaoMateria";
            Sql.Chaves = "codMateria";
            Sql.ParametrosChave = "@codMaterias";
            Sql.CamposSaidaBusca = @"codMateria,DescricaoMateria";
        }

        /// <summary>
        /// Lista de Materiass
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Lista de Materiass</returns>
        public List<EntMateria> Listar()
        {
            List<EntMateria> retMaterias = new List<EntMateria>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retMaterias = bd.Busca(strSql);

            return retMaterias;
        }

        /// <summary>
        /// Lista de Materiass pesquisados
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Lista de Materiass pesquisados</returns>
        public List<EntMateria> Pesquisar(EntMateria Materias)
        {
            List<EntMateria> retMaterias = new List<EntMateria>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Materias.DescricaoMateria != "")
            {
                strSql += " and DescricaoMateria like @DescricaoMateria";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoMateria", "'%" + Materias.DescricaoMateria + "%'");

            // realizando a busca
            retMaterias = bd.Busca(strSql);

            return retMaterias;
        }

        /// <summary>
        /// Grava dados do Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Gravacao dos dados do Materias</returns>
        public bool Gravar(EntMateria Materias)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codMaterias", Materias.CodMateria));
            par.Add(new SqlParameter("@DescricaoMateria", Materias.DescricaoMateria));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbMaterias", Materias.CodMateria);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntMateria Materias)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoMateria", Materias.DescricaoMateria));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbMaterias", Materias.CodMateria);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntMateria Materias)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codMaterias", Materias.CodMateria));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbCursos", Materias.CodMateria);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }
   
    }
}
