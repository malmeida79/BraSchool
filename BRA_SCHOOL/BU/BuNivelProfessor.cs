using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuNivelProfessor
    {
        DaoNivelProfessor objDao = new DaoNivelProfessor();

        /// <summary>
        /// Lista de NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Lista de NivelProfessores</returns>
        public List<EntNivelProfessor> Listar()
        {
            List<EntNivelProfessor> retNivelProfessor = new List<EntNivelProfessor>();


            retNivelProfessor = objDao.Listar();


            return retNivelProfessor;
        }

        /// <summary>
        /// Lista de NivelProfessores pesquisados
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Lista de NivelProfessores pesquisados</returns>
        public List<EntNivelProfessor> Pesquisar(EntNivelProfessor NivelProfessor)
        {

            List<EntNivelProfessor> retNivelProfessor = new List<EntNivelProfessor>();

            retNivelProfessor = objDao.Pesquisar(NivelProfessor);

            return retNivelProfessor;

        }

        /// <summary>
        /// Grava dados do NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Gravacao dos dados do NivelProfessores</returns>
        public bool Gravar(EntNivelProfessor NivelProfessor)
        {

            bool retorno = false;

            retorno = objDao.Gravar(NivelProfessor);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntNivelProfessor NivelProfessor)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(NivelProfessor);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do NivelProfessores
        /// </summary>
        /// <param name="NivelProfessores">Entidade NivelProfessores</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntNivelProfessor NivelProfessor)
        {
            bool retorno = false;

            retorno = objDao.Excluir(NivelProfessor);

            return retorno;
        }

    }

}

