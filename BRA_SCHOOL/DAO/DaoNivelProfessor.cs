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
    class DaoNivelProfessor
    {
        private DaoBase<EntNivelProfessor> bd = new DaoBase<EntNivelProfessor>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbNivelProfessor";
            Sql.TabelaPesquisa = "tbNivelProfessor";
            Sql.Campos = "DescricaoNivel";
            Sql.ParametrosCampo = "@DescricaoNivel";
            Sql.Chaves = "codNivelProfessor";
            Sql.ParametrosChave = "@codNivelProfessores";
            Sql.CamposSaidaBusca = "codNivelProfessor,DescricaoNivel";

        }

        /// <summary>
        /// Lista de NivelProfessoress
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Lista de NivelProfessoress</returns>
        public List<EntNivelProfessor> Listar()
        {
            List<EntNivelProfessor> retNivelProfessores = new List<EntNivelProfessor>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 1";

            // realizando a busca
            retNivelProfessores = bd.Busca(strSql);

            return retNivelProfessores;
        }

        /// <summary>
        /// Lista de NivelProfessoress pesquisados
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Lista de NivelProfessoress pesquisados</returns>
        public List<EntNivelProfessor> Pesquisar(EntNivelProfessor NivelProfessores)
        {
            List<EntNivelProfessor> retNivelProfessores = new List<EntNivelProfessor>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (NivelProfessores.DescricaoNivel != "")
            {
                strSql += " and DescricaoNivel like @DescricaoNivel";
            }

            // Passagem de parametros
            strSql = strSql.Replace("@DescricaoNivel", "'%" + NivelProfessores.DescricaoNivel + "%'");

            // realizando a busca
            retNivelProfessores = bd.Busca(strSql);

            return retNivelProfessores;
        }

        /// <summary>
        /// Grava dados do NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Gravacao dos dados do NivelProfessores</returns>
        public bool Gravar(EntNivelProfessor NivelProfessores)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codNivelProfessores", NivelProfessores.CodNivelProfessor));
            par.Add(new SqlParameter("@DescricaoNivel", NivelProfessores.DescricaoNivel));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbNivelProfessores", NivelProfessores.CodNivelProfessor);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntNivelProfessor NivelProfessores)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoNivel", NivelProfessores.DescricaoNivel));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbNivelProfessores", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntNivelProfessor NivelProfessores)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codNivelProfessores", NivelProfessores.CodNivelProfessor));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbNivelProfessores", NivelProfessores.CodNivelProfessor);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

    }
}
