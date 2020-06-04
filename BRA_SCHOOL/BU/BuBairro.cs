using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuBairro
    {
        DaoBairro objDao = new DaoBairro();

        /// <summary>
        /// Lista de Bairros
        /// </summary>
        /// <param name="Bairros">Entidade Bairros</param>
        /// <returns>Lista de Bairros</returns>
        public List<EntBairro> Listar()
        {
            List<EntBairro> retBairro = new List<EntBairro>();

            retBairro = objDao.Listar();

            return retBairro;
        }

        /// <summary>
        /// Lista de Bairros pesquisados
        /// </summary>
        /// <param name="Bairros">Entidade Bairros</param>
        /// <returns>Lista de Bairros pesquisados</returns>
        public List<EntBairro> Pesquisar(EntBairro Bairro)
        {

            List<EntBairro> retBairro = new List<EntBairro>();

            retBairro = objDao.Pesquisar(Bairro);

            return retBairro;

        }

        /// <summary>
        /// Grava dados do Bairros
        /// </summary>
        /// <param name="Bairros">Entidade Bairros</param>
        /// <returns>Gravacao dos dados do Bairros</returns>
        public bool Gravar(EntBairro Bairro)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Bairro);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Bairros
        /// </summary>
        /// <param name="Bairros">Entidade Bairros</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntBairro Bairro)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Bairro);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Bairros
        /// </summary>
        /// <param name="Bairros">Entidade Bairros</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntBairro Bairro)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Bairro);

            return retorno;
        }

    }

}

