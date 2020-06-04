using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuEstado
    {
        DaoEstado objDao = new DaoEstado();

        /// <summary>
        /// Lista de Estados
        /// </summary>
        /// <param name="Estados">Entidade Estados</param>
        /// <returns>Lista de Estados</returns>
        public List<EntEstado> Listar()
        {
            List<EntEstado> retEstado = new List<EntEstado>();

            retEstado = objDao.Listar();

            return retEstado;
        }

        /// <summary>
        /// Lista de Estados pesquisados
        /// </summary>
        /// <param name="Estados">Entidade Estados</param>
        /// <returns>Lista de Estados pesquisados</returns>
        public List<EntEstado> Pesquisar(EntEstado Estado)
        {

            List<EntEstado> retEstado = new List<EntEstado>();

            retEstado = objDao.Pesquisar(Estado);

            return retEstado;

        }

        /// <summary>
        /// Grava dados do Estados
        /// </summary>
        /// <param name="Estados">Entidade Estados</param>
        /// <returns>Gravacao dos dados do Estados</returns>
        public bool Gravar(EntEstado Estado)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Estado);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Estados
        /// </summary>
        /// <param name="Estados">Entidade Estados</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntEstado Estado)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Estado);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Estados
        /// </summary>
        /// <param name="Estados">Entidade Estados</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntEstado Estado)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Estado);

            return retorno;
        }

    }

}

