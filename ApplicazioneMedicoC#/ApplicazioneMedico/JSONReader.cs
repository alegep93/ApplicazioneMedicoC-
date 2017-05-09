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

        public static void GetJsonString()
        {
            /*string text = "";
            text += File.ReadAllText(@"C:\Users\admin\Documents\Alessandro\ProjectWork\JsonPaziente.txt");

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PazienteJSON));
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(text)))
            {
                PazienteJSON p = (PazienteJSON)serializer.ReadObject(ms);
            }*/

            using (StreamReader r = new StreamReader(@"C:\Users\admin\Documents\Alessandro\ProjectWork\JsonPaziente.txt"))
            {
                string json = r.ReadToEnd();
                List<PazienteJSON> items = JsonConvert.DeserializeObject<List<PazienteJSON>>(json);
            }
        }
    }
}
