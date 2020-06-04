using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuFuncionalidade
    {
        DaoFuncionalidade objDao = new DaoFuncionalidade();

        /// <summary>
        /// Lista de Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Lista de Funcionalidades</returns>
        public List<EntFuncionalidade> Listar()
        {
            List<EntFuncionalidade> retFuncionalidade = new List<EntFuncionalidade>();

            retFuncionalidade = objDao.Listar();

            return retFuncionalidade;
        }

        /// <summary>
        /// Lista de Funcionalidades pesquisados
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Lista de Funcionalidades pesquisados</returns>
        public List<EntFuncionalidade> Pesquisar(EntFuncionalidade Funcionalidade)
        {

            List<EntFuncionalidade> retFuncionalidade = new List<EntFuncionalidade>();

            retFuncionalidade = objDao.Pesquisar(Funcionalidade);

            return retFuncionalidade;

        }

        /// <summary>
        /// Grava dados do Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Gravacao dos dados do Funcionalidades</returns>
        public bool Gravar(EntFuncionalidade Funcionalidade)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Funcionalidade);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntFuncionalidade Funcionalidade)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Funcionalidade);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Funcionalidades
        /// </summary>
        /// <param name="Funcionalidades">Entidade Funcionalidades</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntFuncionalidade Funcionalidade)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Funcionalidade);

            return retorno;
        }

    }

}

