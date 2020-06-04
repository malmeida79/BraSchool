using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuArquivo
    {
        DaoArquivo objDao = new DaoArquivo();

        /// <summary>
        /// Lista de Arquivos
        /// </summary>
        /// <param name="Arquivos">Entidade Arquivos</param>
        /// <returns>Lista de Arquivos</returns>
        public List<EntArquivo> Listar()
        {
            List<EntArquivo> retArquivo = new List<EntArquivo>();

            retArquivo = objDao.Listar();

            return retArquivo;
        }

        /// <summary>
        /// Lista de Arquivos pesquisados
        /// </summary>
        /// <param name="Arquivos">Entidade Arquivos</param>
        /// <returns>Lista de Arquivos pesquisados</returns>
        public List<EntArquivo> Pesquisar(EntArquivo Arquivo)
        {

            List<EntArquivo> retArquivo = new List<EntArquivo>();

            retArquivo = objDao.Pesquisar(Arquivo);

            return retArquivo;

        }

        /// <summary>
        /// Grava dados do Arquivos
        /// </summary>
        /// <param name="Arquivos">Entidade Arquivos</param>
        /// <returns>Gravacao dos dados do Arquivos</returns>
        public bool Gravar(EntArquivo Arquivo)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Arquivo);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Arquivos
        /// </summary>
        /// <param name="Arquivos">Entidade Arquivos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntArquivo Arquivo)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Arquivo);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Arquivos
        /// </summary>
        /// <param name="Arquivos">Entidade Arquivos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntArquivo Arquivo)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Arquivo);

            return retorno;
        }

        /// <summary>
        /// Exportacao de arquivos
        /// </summary>
        /// <param name="Arquivo"></param>
        /// <returns></returns>
        public bool Export(EntArquivo Arquivo)
        {

            bool retorno = false;
            

            return retorno;

        }

        /// <summary>
        /// Importacao de arquivos
        /// </summary>
        /// <param name="Arquivo"></param>
        /// <returns></returns>
        public bool Import(EntArquivo Arquivo)
        {

            bool retorno = false;


            return retorno;

        }
      
    }

}

