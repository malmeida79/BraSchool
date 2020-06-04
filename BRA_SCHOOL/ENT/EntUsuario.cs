using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    /// <summary>
    /// Entidade usuario
    /// </summary>
    class EntUsuario
    {

        public int CodUsuario { get; set; }

        public string LoginUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string EmailUsuario { get; set; }

        public bool BloqueadoUsuario { get; set; }

        public bool AtivoUsuario { get; set; }

        public string SenhaUsuario { get; set; }

    }
}
