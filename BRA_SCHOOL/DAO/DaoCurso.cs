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
    class DaoCurso
    {
        private DaoBase<EntCurso> bd = new DaoBase<EntCurso>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {
            Sql.Tabela = "tbCursos";
            Sql.TabelaPesquisa = "tbCursos";
            Sql.Campos = "DescricaoCurso";
            Sql.ParametrosCampo = "@DescricaoCurso";
            Sql.Chaves = "codCurso";
            Sql.ParametrosChave = "@codCursos";
            Sql.CamposSaidaBusca = @"codCurso,DescricaoCurso";
        }

        /// <summary>
        /// Lista de Cursoss
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Lista de Cursoss</returns>
        public List<EntCurso> Listar()
        {
            List<EntCurso> retCursos = new List<EntCurso>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retCursos = bd.Busca(strSql);

            return retCursos;
        }

        /// <summary>
        /// Lista de Cursoss pesquisados
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Lista de Cursoss pesquisados</returns>
        public List<EntCurso> Pesquisar(EntCurso Cursos)
        {
            List<EntCurso> retCursos = new List<EntCurso>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Cursos.DescricaoCurso != "")
            {
                strSql += " and DescricaoCurso like @DescricaoCurso";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoCurso", "'%" + Cursos.DescricaoCurso + "%'");

            // realizando a busca
            retCursos = bd.Busca(strSql);

            return retCursos;
        }

        /// <summary>
        /// Grava dados do Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Gravacao dos dados do Cursos</returns>
        public bool Gravar(EntCurso Cursos)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codCursos", Cursos.CodCurso));
            par.Add(new SqlParameter("@DescricaoCurso", Cursos.DescricaoCurso));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbCursos", Cursos.CodCurso);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntCurso Cursos)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoCurso", Cursos.DescricaoCurso));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbCursos", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntCurso Cursos)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codCursos", Cursos.CodCurso));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbCursos", Cursos.CodCurso);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
