using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuCidade
    {
        DaoCidade objDao = new DaoCidade();

        /// <summary>
        /// Lista de Cidades
        /// </summary>
        /// <param name="Cidades">Entidade Cidades</param>
        /// <returns>Lista de Cidades</returns>
        public List<EntCidade> Listar()
        {
            List<EntCidade> retCidade = new List<EntCidade>();

            retCidade = objDao.Listar();

            return retCidade;
        }

        /// <summary>
        /// Lista de Cidades pesquisados
        /// </summary>
        /// <param name="Cidades">Entidade Cidades</param>
        /// <returns>Lista de Cidades pesquisados</returns>
        public List<EntCidade> Pesquisar(EntCidade Cidade)
        {

            List<EntCidade> retCidade = new List<EntCidade>();

            retCidade = objDao.Pesquisar(Cidade);

            return retCidade;

        }

        /// <summary>
        /// Grava dados do Cidades
        /// </summary>
        /// <param name="Cidades">Entidade Cidades</param>
        /// <returns>Gravacao dos dados do Cidades</returns>
        public bool Gravar(EntCidade Cidade)
        {

            bool retorno = false;

            retorno = objDao.Gravar(Cidade);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do Cidades
        /// </summary>
        /// <param name="Cidades">Entidade Cidades</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntCidade Cidade)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(Cidade);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do Cidades
        /// </summary>
        /// <param name="Cidades">Entidade Cidades</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntCidade Cidade)
        {
            bool retorno = false;

            retorno = objDao.Excluir(Cidade);

            return retorno;
        }

    }

}

