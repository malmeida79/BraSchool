using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuEndereco
    {
        DaoEndereco objDao = new DaoEndereco();

        /// <summary>
        /// Lista de Enderecos
        /// </summary>
        /// <param name="Enderecos">Entidade Enderecos</param>
        /// <returns>Lista de Enderecos</returns>
        public List<EntEndereco> Listar(EntEndereco Endereco)
        {
            List<EntEndereco> retEndereco = new List<EntEndereco>();

            retEndereco = objDao.Listar();

            return retEndereco;
        }

        /// <summary>
        /// Lista de Enderecos pesquisados
        /// </summary>
        /// <param name="Enderecos">Entidade Enderecos</param>
        /// <returns>Lista de Enderecos pesquisados</returns>
        public List<EntEndereco> Pesquisar(EntEndereco Endereco)
        {

            List<EntEndereco> retEndereco = new List<EntEndereco>();

            retEndereco = objDao.Pesquisar(Endereco);

            return retEndereco;

        }

        /// <summary>
        /// Grava dados do Enderecos
        /// </summary>
        /// <param name="Enderecos">Entidade Enderecos</param>
        /// <returns>Gravacao dos dados do Enderecos</returns>
        public bool Gravar(EntEndereco Endereco)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Endereco);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Enderecos
        /// </summary>
        /// <param name="Enderecos">Entidade Enderecos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntEndereco Endereco)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Endereco);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Enderecos
        /// </summary>
        /// <param name="Enderecos">Entidade Enderecos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntEndereco Endereco)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Endereco);

            return retorno;
        }

    }

}

