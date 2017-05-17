using ApplicazioneMedico.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico
{
    public class JSONManager
    {
        public static T DeserializeJson<T>(string json)
        {
            T result;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                result = (T)serializer.ReadObject(ms);
            }
            return result;
        }
        public static string SerializeJson(Certificato c)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Certificato));
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, c);
            return Encoding.UTF8.GetString(ms.ToArray());


            /*string json = "{\"idCertificato\":\"" + c.idCertificato + "\"," +
                           "\"cod_sanitario\":\"" + c.cod_sanitario + "\"," +
                           "\"cod_medico\":\"" + c.cod_medico + "\"," +
                           "\"data_emissione\":\"" + c.data_emissione + "\"," +
                           "\"cod_patologia\":\"" + c.cod_patologia + "\"," +
                           "\"data_inizio\":\"" + c.data_inizio + "\"," +
                           "\"data_fine\":\"" + c.data_fine + "\"," +
                           "\"tipologia\":\"" + c.tipologia + "\"," +
                           "\"comune\":\"" + c.comune + "\"," +
                           "\"provincia\":\"" + c.provincia + "\"," +
                           "\"indirizzo\":\"" + c.indirizzo + "\"," +
                           "\"CAP\":\"" + c.CAP + "\"," +
                           "\"domicilio\":\"" + c.domicilio + "\"," +
                           "\"note\":\"" + c.note + "\"}";*/
        }
    }
}
