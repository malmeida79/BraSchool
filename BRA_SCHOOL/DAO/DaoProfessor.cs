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
    class DaoProfessor
    {
        private DaoBase<EntProfessor> bd = new DaoBase<EntProfessor>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbProfessores";
            Sql.TabelaPesquisa = "tbProfessores p inner join tbNivelProfessor pn on p.codNivelProfessor = pn.codNivelProfessor";
            Sql.Campos = "NomeProfessor,codNivelProfessor";
            Sql.ParametrosCampo = "@NomeProfessor,@codNivelProfessor";
            Sql.Chaves = "codProfessor";
            Sql.ParametrosChave = "@codProfessores";
            Sql.CamposSaidaBusca = @"codProfessor
                                    ,NomeProfessor
                                    ,p.codNivelProfessor
                                    ,descricaoNivel";
        }

        /// <summary>
        /// Lista de Professoress
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Lista de Professoress</returns>
        public List<EntProfessor> Listar()
        {
            List<EntProfessor> retProfessores = new List<EntProfessor>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retProfessores = bd.Busca(strSql);

            return retProfessores;
        }

        /// <summary>
        /// Lista de Professoress pesquisados
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Lista de Professoress pesquisados</returns>
        public List<EntProfessor> Pesquisar(EntProfessor Professores)
        {
            List<EntProfessor> retProfessores = new List<EntProfessor>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (Professores.NomeProfessor != "")
            {
                strSql += " and NomeProfessor like @NomeProfessor";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@NomeProfessor", "'%" + Professores.NomeProfessor + "%'");

            // realizando a busca
            retProfessores = bd.Busca(strSql);

            return retProfessores;
        }

        /// <summary>
        /// Grava dados do Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Gravacao dos dados do Professores</returns>
        public bool Gravar(EntProfessor Professores)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();
            
            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codProfessores", Professores.CodProfessor));
            par.Add(new SqlParameter("@NomeProfessor", Professores.NomeProfessor));
            par.Add(new SqlParameter("@codNivelProfessor", Professores.CodNivelProfessor));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbProfessores", Professores.CodProfessor);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntProfessor Professores)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@NomeProfessor", Professores.NomeProfessor));
            par.Add(new SqlParameter("@codNivelProfessor", Professores.CodNivelProfessor));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbProfessores", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntProfessor Professores)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codProfessores", Professores.CodProfessor));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbProfessores", Professores.CodProfessor);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
