using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    class EntPeriodo
    {

        /// <summary>
        /// Codigo do Periodo
        /// </summary>
        public int CodPeriodo { get; set; }

        /// <summary>
        /// Nome do periodo
        /// </summary>
        public string DescricaoPeriodo { get; set; }


        /// <summary>
        /// Horario de Inicio do Periodo
        /// </summary>
        public string HoraInicio { get; set; }

        /// <summary>
        ///  Hora Fim do Periodo
        /// </summary>
        public string HoraFim { get; set; }

    }
}
