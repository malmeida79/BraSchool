using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    class EntEndereco: EntBairro
    {

        
        /// <summary>
        /// Codigo do logradouro do Endereco
        /// </summary>
        public int CodLogradouro { get; set; }

        /// <summary>
        /// Descricao do Endereco
        /// </summary>
        public string DescricaoLogradouro { get; set; }

        /// <summary>
        /// Codigo do Endereco
        /// </summary>
        public int CodEndereco { get; set; }

        /// <summary>
        /// Descricao do Endereco
        /// </summary>
        public string DescricaoEndereco { get; set; }

        /// <summary>
        /// Cep do Endereco
        /// </summary>
        public string CepEndereco { get; set; }

    }
}
