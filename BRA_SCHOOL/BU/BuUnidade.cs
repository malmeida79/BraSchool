using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuUnidade
    {
        DaoUnidade objDao = new DaoUnidade();

        /// <summary>
        /// Lista de Unidades
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Lista de Unidades</returns>
        public List<EntUnidade> Listar()
        {
            List<EntUnidade> retUnidade = new List<EntUnidade>();

            retUnidade = objDao.Listar();

            return retUnidade;
        }

        /// <summary>
        /// Lista de Unidades pesquisados
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Lista de Unidades pesquisados</returns>
        public List<EntUnidade> Pesquisar(EntUnidade Unidade)
        {

            List<EntUnidade> retUnidade = new List<EntUnidade>();

            retUnidade = objDao.Pesquisar(Unidade);

            return retUnidade;

        }

        /// <summary>
        /// Grava dados do Unidade
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Gravacao dos dados do Unidade</returns>
        public bool Gravar(EntUnidade Unidade)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Unidade);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Unidade
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntUnidade Unidade)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Unidade);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Unidade
        /// </summary>
        /// <param name="Unidade">Entidade Unidade</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntUnidade Unidade)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Unidade);

            return retorno;
        }

    }

}

