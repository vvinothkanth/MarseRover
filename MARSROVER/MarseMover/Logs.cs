using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarseMover
{
    public class Log
    {
        private static string m_exePath = string.Empty;

        public static void Write(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter streamWriter = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    FileWirite(logMessage, streamWriter);
                }
            }
            catch (Exception ex) { }
        }

        private static void FileWirite(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex) { }
        }
    }
}

