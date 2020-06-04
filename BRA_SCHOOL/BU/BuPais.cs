using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuPais
    {
        DaoPais objDao = new DaoPais();

        /// <summary>
        /// Lista de Paisess
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Lista de Paisess</returns>
        public List<EntPais> Listar()
        {
            List<EntPais> retPais = new List<EntPais>();

            retPais = objDao.Listar();

            return retPais;
        }

        /// <summary>
        /// Lista de Paisess pesquisados
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Lista de Paisess pesquisados</returns>
        public List<EntPais> Pesquisar(EntPais Pais)
        {

            List<EntPais> retPais = new List<EntPais>();

            retPais = objDao.Pesquisar(Pais);

            return retPais;

        }

        /// <summary>
        /// Grava dados do Paises
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Gravacao dos dados do Paises</returns>
        public bool Gravar(EntPais Pais)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Pais);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Paises
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntPais Pais)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Pais);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Paises
        /// </summary>
        /// <param name="Paises">Entidade Paises</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntPais Pais)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Pais);

            return retorno;
        }

    }

}

