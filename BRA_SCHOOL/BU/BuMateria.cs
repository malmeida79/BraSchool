using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuMateria
    {
        DaoMateria objDao = new DaoMateria();

        /// <summary>
        /// Lista de Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Lista de Materias</returns>
        public List<EntMateria> Listar(EntMateria Materia)
        {
            List<EntMateria> retMateria = new List<EntMateria>();

            retMateria = objDao.Listar();

            return retMateria;
        }

        /// <summary>
        /// Lista de Materias pesquisados
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Lista de Materias pesquisados</returns>
        public List<EntMateria> Pesquisar(EntMateria Materia)
        {

            List<EntMateria> retMateria = new List<EntMateria>();

            retMateria = objDao.Pesquisar(Materia);

            return retMateria;

        }

        /// <summary>
        /// Grava dados do Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Gravacao dos dados do Materias</returns>
        public bool Gravar(EntMateria Materia)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Materia);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntMateria Materia)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Materia);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Materias
        /// </summary>
        /// <param name="Materias">Entidade Materias</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntMateria Materia)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Materia);

            return retorno;
        }

    }

}

