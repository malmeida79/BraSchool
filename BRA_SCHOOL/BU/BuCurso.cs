using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuCurso
    {
        DaoCurso objDao = new DaoCurso();

        /// <summary>
        /// Lista de Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Lista de Cursos</returns>
        public List<EntCurso> Listar()
        {
            List<EntCurso> retCurso = new List<EntCurso>();

            retCurso = objDao.Listar();

            return retCurso;
        }

        /// <summary>
        /// Lista de Cursos pesquisados
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Lista de Cursos pesquisados</returns>
        public List<EntCurso> Pesquisar(EntCurso Curso)
        {

            List<EntCurso> retCurso = new List<EntCurso>();

            retCurso = objDao.Pesquisar(Curso);

            return retCurso;

        }

        /// <summary>
        /// Grava dados do Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Gravacao dos dados do Cursos</returns>
        public bool Gravar(EntCurso Curso)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Curso);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntCurso Curso)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Curso);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Cursos
        /// </summary>
        /// <param name="Cursos">Entidade Cursos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntCurso Curso)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Curso);

            return retorno;
        }

    }

}

