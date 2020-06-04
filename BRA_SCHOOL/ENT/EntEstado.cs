using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    class EntEstado : EntPais
    {

        /// <summary>
        /// Codigo do Estado
        /// </summary>
        public int CodEstado { get; set; }

        /// <summary>
        /// Descricao do Estado
        /// </summary>
        public string DescricaoEstado { get; set; }

    }
}
