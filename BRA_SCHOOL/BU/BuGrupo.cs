using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuGrupo
    {
        DaoGrupo objDao = new DaoGrupo();

        /// <summary>
        /// Lista de Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Lista de Grupos</returns>
        public List<EntGrupo> Listar()
        {
            List<EntGrupo> retGrupo = new List<EntGrupo>();

            retGrupo = objDao.Listar();

            return retGrupo;
        }

        /// <summary>
        /// Lista de Grupos pesquisados
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Lista de Grupos pesquisados</returns>
        public List<EntGrupo> Pesquisar(EntGrupo Grupo)
        {

            List<EntGrupo> retGrupo = new List<EntGrupo>();

            retGrupo = objDao.Pesquisar(Grupo);

            return retGrupo;

        }

        /// <summary>
        /// Grava dados do Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Gravacao dos dados do Grupos</returns>
        public bool Gravar(EntGrupo Grupo)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Grupo);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntGrupo Grupo)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Grupo);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Grupos
        /// </summary>
        /// <param name="Grupos">Entidade Grupos</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntGrupo Grupo)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Grupo);

            return retorno;
        }

    }

}

