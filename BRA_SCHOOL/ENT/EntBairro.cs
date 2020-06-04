using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    class EntBairro: EntCidade
    {

        /// <summary>
        /// Codigo do Bairro
        /// </summary>
        public int CodBairro { get; set; }
        

        /// <summary>
        /// Descricao do Bairro
        /// </summary>
        public string DescricaoBairro { get; set; }

    }
}
