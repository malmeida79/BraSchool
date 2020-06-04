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
    class DaoArquivo
    {
        private DaoBase<EntArquivo> bd = new DaoBase<EntArquivo>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbArquivos";
            Sql.TabelaPesquisa = @"tbArquivos";

            Sql.Campos = "descricaoArquivo,camposArquivo,comandoExportacao";
            Sql.ParametrosCampo = "@descricaoArquivo,@camposArquivo,@comandoExportacao";
            Sql.Chaves = "codArquivo";
            Sql.ParametrosChave = "@codArquivo";
            Sql.CamposSaidaBusca = @"descricaoArquivo,camposArquivo,comandoExportacao";
        }

        /// <summary>
        /// Lista de Arquivos
        /// </summary>
        /// <param name="Arquivo">Entidade Arquivo</param>
        /// <returns>Lista de Arquivos</returns>
        public List<EntArquivo> Listar()
        {
            List<EntArquivo> retArquivo = new List<EntArquivo>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";

            // realizando a busca
            retArquivo = bd.Busca(strSql);

            return retArquivo;
        }

        /// <summary>
        /// Lista de Arquivos pesquisados
        /// </summary>
        /// <param name="Arquivo">Entidade Arquivo</param>
        /// <returns>Lista de Arquivos pesquisados</returns>
        public List<EntArquivo> Pesquisar(EntArquivo Arquivo)
        {
            List<EntArquivo> retArquivo = new List<EntArquivo>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            // Passagem de parametros
            if (Arquivo.DescricaoArquivo != "")
            {
                strSql += " and DescricaoArquivo like @DescricaoArquivo";
                strSql = strSql.Replace("@DescricaoArquivo", "'%" + Arquivo.DescricaoArquivo + "%'");
            }

            // realizando a busca
            retArquivo = bd.Busca(strSql);

            return retArquivo;
        }

        /// <summary>
        /// Grava dados do Arquivo
        /// </summary>
        /// <param name="Arquivo">Entidade Arquivo</param>
        /// <returns>Gravacao dos dados do Arquivo</returns>
        public bool Gravar(EntArquivo Arquivo)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@codArquivo", Arquivo.CodArquivo));
            par.Add(new SqlParameter("@ComandoExportacao", Arquivo.CamposArquivo));
            par.Add(new SqlParameter("@ComandoExportacao", Arquivo.ComandoExportacao));
            par.Add(new SqlParameter("@DescricaoArquivo", Arquivo.DescricaoArquivo));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbArquivo", Arquivo.CodArquivo);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do Arquivo
        /// </summary>
        /// <param name="Arquivo">Entidade Arquivo</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntArquivo Arquivo)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@DescricaoArquivo", Arquivo.DescricaoArquivo));
            par.Add(new SqlParameter("@ComandoExportacao", Arquivo.CamposArquivo));
            par.Add(new SqlParameter("@ComandoExportacao", Arquivo.ComandoExportacao));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbArquivo", 0);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Arquivo
        /// </summary>
        /// <param name="Arquivo">Entidade Arquivo</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntArquivo Arquivo)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codArquivo", Arquivo.CodArquivo));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbArquivo", Arquivo.CodArquivo);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;

        }

    }
}
