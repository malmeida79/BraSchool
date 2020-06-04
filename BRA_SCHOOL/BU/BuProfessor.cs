using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuProfessor
    {
        DaoProfessor objDao = new DaoProfessor();

        /// <summary>
        /// Lista de Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Lista de Professores</returns>
        public List<EntProfessor> Listar(EntProfessor Professor)
        {
            List<EntProfessor> retProfessor = new List<EntProfessor>();

            retProfessor = objDao.Listar();

            return retProfessor;
        }

        /// <summary>
        /// Lista de Professores pesquisados
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Lista de Professores pesquisados</returns>
        public List<EntProfessor> Pesquisar(EntProfessor Professor)
        {

            List<EntProfessor> retProfessor = new List<EntProfessor>();

            retProfessor = objDao.Pesquisar(Professor);

            return retProfessor;

        }

        /// <summary>
        /// Grava dados do Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Gravacao dos dados do Professores</returns>
        public bool Gravar(EntProfessor Professor)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Professor);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntProfessor Professor)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Professor);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Professores
        /// </summary>
        /// <param name="Professores">Entidade Professores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntProfessor Professor)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Professor);

            return retorno;
        }

    }

}

