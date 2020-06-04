using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BRA_SCHOOL.Opcoes;

namespace BRA_SCHOOL.UTILS
{
    /// <summary>
    /// Classe para registro de logs
    /// </summary>
    public static class LogFile
    {
        static string logPath = Properties.Settings.Default.LogPath;
        static string nomeLogFile = Properties.Settings.Default.NomeLogFile;
        static bool logAtivo = Properties.Settings.Default.LogAtivo;        

        /// <summary>
        /// Resgistra LOG no formato [dd/mm/yyyy 00:00:000 - Usuario]: << LOG >>
        /// </summary>
        /// <param name="fraseLog">Mensagem a ser registrada</param>
        public static void RegistraLog(string fraseLog) {

            if (logAtivo)
            {
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                StreamWriter strWrite = new StreamWriter(logPath + nomeLogFile, true);
                strWrite.WriteLine("[" + DateTime.Now.ToString() + " - " + Logado.logadoLogin + "]: " + fraseLog );
                strWrite.Close();
                strWrite.Dispose();
            }
        }

    }
}
