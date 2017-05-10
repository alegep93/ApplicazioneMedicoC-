using ApplicazioneMedico.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico
{
    public class JSONReader
    {

        public static Paziente GetJsonString()
        {
            string text = "";
            Paziente p = new Paziente();

            text = File.ReadAllText(@"C:\Users\admin\Documents\Alessandro\ProjectWork\JsonPaziente.json");

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Paziente));
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(text)))
            {
                p = (Paziente)serializer.ReadObject(ms);
            }

            return p;
        }
    }
}
