using ApplicazioneMedico.DAO;
using ApplicazioneMedico.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicazioneMedico.API
{
    public class ApiRestClient : JSONManager
    {
        private static WebClient syncClient = new WebClient();
        private static string codMed = ConfigurationManager.GetCodiceMedico();
        private static string serverAddr = ConfigurationManager.GetServerAddress();

        public static RootObject<Paziente> GetPazientiDataFromServer()
        {
            string url = serverAddr + "/ApiServer/Paziente/all/" + codMed;
            string jsonPazienti = "";

            try
            {
                syncClient.Encoding = Encoding.UTF8;
                jsonPazienti = syncClient.DownloadString(url);
                RootObject<Paziente> json = DeserializeJson<RootObject<Paziente>>(jsonPazienti);

                return json;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static RootObject<Patologia> GetPatologieDataFromServer()
        {
            string url = serverAddr + "/ApiServer2/Patologia/all";
            string jsonPatologie = "";

            try
            {
                syncClient.Encoding = Encoding.UTF8;
                jsonPatologie = syncClient.DownloadString(url);
                RootObject<Patologia> json = DeserializeJson<RootObject<Patologia>>(jsonPatologie);

                return json;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static RootObject<Certificato> GetCertificatiDataFromServer()
        {
            string url = serverAddr + "/ApiServer/Certificato/get/" + codMed;
            string jsonCertificati = "";

            try
            {
                syncClient.Encoding = Encoding.UTF8;
                jsonCertificati = syncClient.DownloadString(url);
                RootObject<Certificato> json = DeserializeJson<RootObject<Certificato>>(jsonCertificati);

                return json;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool SendCertificatiToServer(List<Certificato> cList)
        {
            string url = serverAddr + "/ApiServer/Certificato/write";
            syncClient.Headers.Add("Content-Type", "application/json");

            foreach (Certificato c in cList)
            {
                syncClient.Encoding = Encoding.UTF8;
                string jsonCertificato = JSONManager.SerializeJson(c);
                syncClient.UploadString(url, jsonCertificato);
            }

            return true;
        }
    }
}
