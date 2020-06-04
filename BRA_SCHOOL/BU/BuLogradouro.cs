using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuLogradouro
    {
        DaoLogradouro objDao = new DaoLogradouro();

        /// <summary>
        /// Lista de Logradouros
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Lista de Logradouros</returns>
        public List<EntLogradouro> Listar()
        {
            List<EntLogradouro> retLogradouro = new List<EntLogradouro>();

            retLogradouro = objDao.Listar();

            return retLogradouro;
        }

        /// <summary>
        /// Lista de Logradouros pesquisados
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Lista de Logradouros pesquisados</returns>
        public List<EntLogradouro> Pesquisar(EntLogradouro Logradouro)
        {

            List<EntLogradouro> retLogradouro = new List<EntLogradouro>();

            retLogradouro = objDao.Pesquisar(Logradouro);

            return retLogradouro;

        }

        /// <summary>
        /// Grava dados do Logradouro
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Gravacao dos dados do Logradouro</returns>
        public bool Gravar(EntLogradouro Logradouro)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Logradouro);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Logradouro
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntLogradouro Logradouro)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Logradouro);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Logradouro
        /// </summary>
        /// <param name="Logradouro">Entidade Logradouro</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntLogradouro Logradouro)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Logradouro);

            return retorno;
        }

    }

}

