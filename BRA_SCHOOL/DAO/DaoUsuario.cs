using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.Opcoes;
using BRA_SCHOOL.UTILS;
using BRA_SCHOOL.MakeSql;

namespace BRA_SCHOOL.DAO
{
    class DaoUsuario
    {
        private DaoBase<EntUsuario> bd = new DaoBase<EntUsuario>();

        // Configurando os dados para construcao 
        // de comando SQL
        public void ConfiguraSql()
        {

            Sql.Tabela = "tbUsuarios";
            Sql.TabelaPesquisa = "tbUsuarios";
            Sql.Campos = "NomeUsuario,EmailUsuario,LoginUsuario,SenhaUsuario,NivelUsuario,BloqueadoUsuario,AtivoUsuario";
            Sql.ParametrosCampo = "@nomeUsuario,@emailUsuario,@loginUsuario,@senhaUsuario,@nivelUsuario,@bloqueiaUsuario,@ativaUsuario";
            Sql.Chaves = "codUsuario";
            Sql.ParametrosChave = "@codUsuario";
            Sql.CamposSaidaBusca = @"codUsuario
                                    ,NomeUsuario
                                    ,EmailUsuario
                                    ,LoginUsuario
                                    ,SenhaUsuario
                                    ,NivelUsuario
                                    ,BloqueadoUsuario
                                    ,AtivoUsuario";

        }

        /// <summary>
        /// Realizar login do usuario na rede e devolver
        /// um objeto com os seus dados.
        /// </summary>
        /// <param name="usuario">Dados do usuario em login</param>
        /// <returns>Objeto carregado com dados do usuario e 
        /// true caso logado e falso caso nao.</returns>
        public bool Logar(EntUsuario usuario)
        {
            // variaveis
            bool retorno = false;
            SqlDataReader drLoga;
            string strSql;

            // conectando o banco de dados
            bd.Conectar();

            // comando sql que ira consultar o usuario
            strSql = @"
                    select top 1
                        * 
                    from 
                        tbUsuarios 
                    where 
                        loginUsuario='" + usuario.LoginUsuario + "' and senhaUsuario='" + usuario.SenhaUsuario + "'";

            // Conta quantos registros retorna, caso mais que 1
            // significa que o login e senha existem
            drLoga = bd.GeraReader(strSql);

            // foram encontradas linhas? (traduçao hasrows: Existem linhas?)
            if (drLoga.HasRows)
            {
                //configura o objeto usuario logado
                while (drLoga.Read())
                {
                    Logado.logadoCod = Convert.ToInt32(drLoga["codUsuario"].ToString());
                    Logado.logadoLogin = drLoga["loginUsuario"].ToString();
                    Logado.logadoBloqueado = Convert.ToBoolean(drLoga["bloqueiaUsuario"].ToString());
                }

                retorno = true;
            }

            bd.Desconectar();

            return retorno;

        }

        /// <summary>
        /// Lista de usuarios
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Lista de usuarios</returns>
        public List<EntUsuario> Listar()
        {
            List<EntUsuario> retUsuario = new List<EntUsuario>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect() + " order by 2";                    

            // Busca os dados na base de dados
            retUsuario = bd.Busca(strSql);

            return retUsuario;
        }

        /// <summary>
        /// Lista de usuarios pesquisados
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Lista de usuarios pesquisados</returns>
        public List<EntUsuario> Pesquisar(EntUsuario usuario)
        {
            List<EntUsuario> retUsuario = new List<EntUsuario>();

            ConfiguraSql();

            string strSql = Sql.CriarSelect();

            if (usuario.NomeUsuario != "")
            {
                strSql += " and nomeUsuario like @nomeUsuario";
                strSql = strSql.Replace("@nomeUsuario", "'%" + usuario.NomeUsuario + "%'");
            }

            if (usuario.LoginUsuario != "")
            {
                strSql += " and loginUsuario = @loginUsuario";
                strSql = strSql.Replace("@loginUsuario", "'" + usuario.LoginUsuario + "'");
            }

            if (usuario.EmailUsuario != "")
            {
                strSql += " and emailUsuario = @emailUsuario";
                strSql = strSql.Replace("@emailUsuario", "'" + usuario.EmailUsuario + "'");
            }

            if (usuario.AtivoUsuario == true)
            {
                strSql += " and ativousuario = @ativaUsuario";
                strSql = strSql.Replace("@ativaUsuario", "'" + usuario.AtivoUsuario.ToString() + "'");
            }

            if (usuario.BloqueadoUsuario == true)
            {
                strSql += " and bloqueadoUsuario = @bloqueiaUsuario";
                strSql = strSql.Replace("@bloqueiaUsuario", "'" + usuario.BloqueadoUsuario.ToString() + "'");
            }

            // Busca os dados na base de dados
            retUsuario = bd.Busca(strSql);

            return retUsuario;
        }

        /// <summary>
        /// Grava dados do usuario
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Gravacao dos dados do usuario</returns>
        public bool Gravar(EntUsuario usuario)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarUpdate();

            // Passagem de parametros
            par.Add(new SqlParameter("@loginUsuario", usuario.LoginUsuario));
            par.Add(new SqlParameter("@senhaUsuario", usuario.SenhaUsuario));
            par.Add(new SqlParameter("@emailUsuario", usuario.EmailUsuario));
            par.Add(new SqlParameter("@nomeUsuario", usuario.NomeUsuario));
            par.Add(new SqlParameter("@bloqueiaUsuario", usuario.BloqueadoUsuario));
            par.Add(new SqlParameter("@ativaUsuario", usuario.AtivoUsuario));
            par.Add(new SqlParameter("@codUsuario", usuario.CodUsuario));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "update", "tbUsuarios", usuario.CodUsuario);
            
            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Cadastra dados do usuario
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntUsuario usuario)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarInsert();

            // Passagem de parametros
            par.Add(new SqlParameter("@loginUsuario", usuario.LoginUsuario));
            par.Add(new SqlParameter("@senhaUsuario", usuario.SenhaUsuario));
            par.Add(new SqlParameter("@emailUsuario", usuario.EmailUsuario));
            par.Add(new SqlParameter("@nomeUsuario", usuario.NomeUsuario));
            par.Add(new SqlParameter("@bloqueiaUsuario", usuario.BloqueadoUsuario));
            par.Add(new SqlParameter("@ativaUsuario", usuario.AtivoUsuario));
           
            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "insert", "tbUsuarios", usuario.CodUsuario);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do usuario
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntUsuario usuario)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            ConfiguraSql();

            string sqlStr = Sql.CriarDelete();

            // Passagem de parametros
            par.Add(new SqlParameter("@codUsuario", usuario.CodUsuario));

            // Registrando Historico
            bd.RegistraHistorico(Logado.logadoCod, "delete", "tbUsuarios", usuario.CodUsuario);

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }

        /// <summary>
        /// Bloqueia usuario apos tentativas
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Bloqueia(EntUsuario usuario)
        {
            bool retorno = false;
            List<SqlParameter> par = new List<SqlParameter>();

            string sqlStr = @"
                                update tbUsuarios set
                                    bloqueiaUsuario = 1,
                                where
                                    codUsuario = @codUsuario
                                ";

            // Passagem de parametros
            par.Add(new SqlParameter("@codUsuario", usuario.CodUsuario));

            // Finalizando comando
            retorno = bd.ExecutaComandoSemRetorno(sqlStr, CommandType.Text, par);

            return retorno;
        }
    }
}
