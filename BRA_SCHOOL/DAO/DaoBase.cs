using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using BRA_SCHOOL.UTILS;

namespace BRA_SCHOOL.DAO
{
    class DaoBase<T>
    {
        string cnString = Properties.Settings.Default.DBCnstr;
        bool histAtivo = Properties.Settings.Default.HistAtivo;

        SqlConnection cn;
        SqlCommand cmd;

        /// <summary>
        /// conecta Banco de dados
        /// </summary>
        public void Conectar()
        {
            cn = new SqlConnection(cnString);
            cn.Open();
        }

        /// <summary>
        /// Desconecta banco de dados se conectado
        /// </summary>
        public void Desconectar()
        {

            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }

        }

        /// <summary>
        /// Contagem de linhas
        /// </summary>
        /// <param name="comando">Comando SQl a ser executado</param>
        /// <returns>Quantidade de linhas</returns>
        public int ContarLinhas(string comando)
        {

            int retorno = 0;

            SqlCommand cmd = new SqlCommand(comando, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    retorno++;
                }
            }

            dr.Dispose();

            return retorno;

        }

        /// <summary>
        /// Metodo de Busca Generico, Devolve uma entidade do tipo
        /// passado na classe carregada com os dados.
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public List<T> Busca(string comando)
        {

            Conectar();

            // lista para devolver os dados
            List<T> lista = new List<T>();

            // descobrindo o tipo da lista
            Type t = typeof(T);

            // consultando os dados
            SqlCommand cmd = new SqlCommand(comando, cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    // instanciando o objeto que ira transportar os dados 
                    // para a lista
                    object o = Activator.CreateInstance(t);

                    // descobre as propriedades do objeto.
                    PropertyInfo[] arrP = o.GetType().GetProperties();

                    // carrega o objeto
                    foreach (PropertyInfo p in arrP)
                    {
                        //try
                        //{
                        if (dr[p.Name] != System.DBNull.Value)
                        {
                            o.GetType().GetProperty(p.Name).SetValue(o, Convert.ChangeType(dr[p.Name], p.PropertyType, System.Globalization.CultureInfo.CurrentCulture), null);
                        }
                        //}
                        //catch (Exception)
                        //{ 
                        //}

                    }

                    // adiciona o objeto a lista
                    lista.Add((T)o);
                }
            }

            Desconectar();

            // devolve a lista carregada
            return lista;

        }

        /// <summary>
        /// Busca dados conforme comando informado
        /// </summary>
        /// <param name="comando">Comando a ser executado</param>
        /// <returns>DataReader com os dados</returns>
        public SqlDataReader GeraReader(string comando)
        {

            SqlCommand cmd = new SqlCommand(comando, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }

        /// <summary>
        /// Executa um comando sem retorno de informacoes
        /// </summary>
        /// <returns>True caso sucesso.</returns>
        public bool ExecutaComandoSemRetorno(string comando, CommandType tipoComando, List<SqlParameter> paramList, int tempo = 20)
        {

            bool retorno = false;

            try
            {

                Conectar();

                cmd = new SqlCommand(comando, cn);
                cmd.CommandType = tipoComando;
                cmd.CommandTimeout = tempo;

                foreach (var parametro in paramList)
                {
                    cmd.Parameters.Add(parametro);
                }

                retorno = true;

                cmd.ExecuteNonQuery();

                Desconectar();

            }
            catch (Exception ex)
            {
                LogFile.RegistraLog("Erro:" + ex.ToString());
                retorno = false;
            }
            finally
            {
                cmd.Dispose();
            }

            return retorno;

        }

        /// <summary>
        /// Encerra Comando
        /// </summary>
        public void EncerraComando()
        {
            cmd.Dispose();
        }

        /// <summary>
        /// Registra Historico de alteracoes
        /// </summary>
        /// <param name="codUsuario"></param>
        /// <param name="acao"></param>
        /// <param name="tabela"></param>
        /// <param name="chaveAlterada"></param>
        public void RegistraHistorico(int codUsuario, string acao, string tabela, int chaveAlterada)
        {

            if (histAtivo)
            {
                string comando = @"
                                INSERT INTO TBHISTORICO (
	                                 CODUSUARIO
	                                ,ACAO
	                                ,DATA
	                                ,TABELA
	                                ,CHAVEALTERADA
                                ) VALUES (
	                                 @CODUSUARIO
	                                ,@ACAO
	                                ,GETDATE()
	                                ,@TABELA
	                                ,@CHAVEALTERADA
                                )";

                comando = comando.Replace("@CODUSUARIO", "'" + codUsuario.ToString() + "'");
                comando = comando.Replace("@ACAO", "'" + acao + "'");
                comando = comando.Replace("@TABELA", "'" + tabela + "'");
                comando = comando.Replace("@CHAVEALTERADA", "'" + chaveAlterada + "'");

                Conectar();

                cmd = new SqlCommand(comando, cn);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                Desconectar();
            }

        }
    }
}
