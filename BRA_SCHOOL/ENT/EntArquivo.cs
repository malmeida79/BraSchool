using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRA_SCHOOL.ENT
{
    class EntArquivo
    {

        /// <summary>
        /// codigo do Arquivo
        /// </summary>
        public int CodArquivo { get; set; }

        /// <summary>
        /// Nome do Arquivo
        /// </summary>
        public string DescricaoArquivo { get; set; }
        

        /// <summary>
        /// Campos da Exportação
        /// </summary>
        public string CamposArquivo { get; set; }


        /// <summary>
        /// Comando Geracao Arquivo
        /// </summary>
        public string ComandoExportacao { get; set; }


    }
}
