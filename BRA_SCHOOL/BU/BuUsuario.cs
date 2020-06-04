using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRA_SCHOOL.ENT;
using BRA_SCHOOL.DAO;

namespace BRA_SCHOOL.BU
{
    class BuUsuario
    {

        DaoUsuario objDao = new DaoUsuario();

        /// <summary>
        /// Realizar Login
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Realiza login ou nao</returns>
        public bool Logar(EntUsuario usuario)
        {

            bool retorno = false;

            if (objDao.Logar(usuario))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Lista de usuarios
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Lista de usuarios</returns>
        public List<EntUsuario> Listar(EntUsuario usuario)
        {
            List<EntUsuario> retUsuario = new List<EntUsuario>();

            retUsuario = objDao.Listar();

            return retUsuario;
        }

        /// <summary>
        /// Lista de usuarios pesquisados
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Lista de usuarios pesquisados</returns>
        public List<EntUsuario> Pesquisar(EntUsuario usuario) {

            List<EntUsuario> retUsuario = new List<EntUsuario>();

            retUsuario = objDao.Pesquisar(usuario);

            return retUsuario;

        }

        /// <summary>
        /// Grava dados do usuario
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Gravacao dos dados do usuario</returns>
        public bool Gravar(EntUsuario usuario) {
            
            bool retorno = false;

            retorno = objDao.Gravar(usuario);

            return retorno;

        }

        /// <summary>
        /// Cadastra dados do usuario
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Cadastrar(EntUsuario usuario)
        {
            bool retorno = false;

            retorno = objDao.Cadastrar(usuario);

            return retorno;
        }

        /// <summary>
        /// Exclui dados do usuario
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Excluir(EntUsuario usuario)
        {
            bool retorno = false;

            retorno = objDao.Excluir(usuario);

            return retorno;
        }

        /// <summary>
        /// Bloqueia usuario apos tentativas
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        /// <returns>Retorna sucesso ou falha</returns>
        public bool Bloqueia(EntUsuario usuario)
        {
            bool retorno = false;

            retorno = objDao.Bloqueia(usuario);

            return retorno;
        }

    }
}
