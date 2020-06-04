using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuSala
    {

        DaoSala objDao = new DaoSala();

        /// <summary>
        /// Lista de Salas
        /// </summary>
        /// <param name="Salas">Entidade Salas</param>
        /// <returns>Lista de Salas</returns>
        public List<EntSala> Listar()
        {
            List<EntSala> retSala = new List<EntSala>();

            retSala = objDao.Listar();

            return retSala;
        }

        /// <summary>
        /// Lista de Salas pesquisados
        /// </summary>
        /// <param name="Salas">Entidade Salas</param>
        /// <returns>Lista de Salas pesquisados</returns>
        public List<EntSala> Pesquisar(EntSala Sala)
        {

            List<EntSala> retSala = new List<EntSala>();

            retSala = objDao.Pesquisar(Sala);

            return retSala;

        }

        /// <summary>
        /// Grava dados do Salas
        /// </summary>
        /// <param name="Salas">Entidade Salas</param>
        /// <returns>Gravacao dos dados do Salas</returns>
        public bool Gravar(EntSala Sala)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Sala);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Salas
        /// </summary>
        /// <param name="Salas">Entidade Salas</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntSala Sala)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Sala);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Salas
        /// </summary>
        /// <param name="Salas">Entidade Salas</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntSala Sala)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Sala);

            return retorno;
        }

    }
}
