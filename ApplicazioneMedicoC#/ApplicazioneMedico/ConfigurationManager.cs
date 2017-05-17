using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico
{
    public class ConfigurationManager
    {
        private static string fileName = "../../config.ini";

        private static string splitFileText(string line)
        {

            string res = line.Split('>')[1];
            res = res.Trim();
            return res;
        }
        public static string GetServerAddress()
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string serverAddr = splitFileText(lines[0]);
            return serverAddr;
        }
        public static string GetCodiceMedico()
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            string codMed = splitFileText(lines[1]);
            return codMed;
        }
    }
}
