using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    class EntProfessor:EntNivelProfessor
    {

        /// <summary>
        /// Codigo da Professores
        /// </summary>
        public int CodProfessor { get; set; }

        /// <summary>
        /// Descricao da Professores
        /// </summary>
        public string NomeProfessor { get; set; }

    }       
}
