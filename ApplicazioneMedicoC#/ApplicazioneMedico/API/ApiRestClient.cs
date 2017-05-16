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

        public static RootObject<Paziente> GetPazientiDataFromServer()
        {
            string url = "http://192.168.4.159:8080/ApiServer/Paziente/all/1";
            string jsonPazienti = "";

            try
            {
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
            string url = "http://192.168.4.159:8080/ApiServer/Patologia/all";
            string jsonPatologie = "";

            try
            {
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
            string url = "http://192.168.4.159:8080/ApiServer/Certificato/get/1";
            string jsonCertificati = "";

            try
            {
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
            string url = "http://192.168.4.159:8080/ApiServer/Certificato/write";
            syncClient.Headers.Add("Content-Type", "application/json");

            foreach (Certificato c in cList)
            {
                string jsonCertificato = JSONManager.SerializeJson(c);

                if(c.data_emissione > MedicoDAO.GetLastSyncDate())
                    syncClient.UploadString(url, jsonCertificato);
            }

            return true;

            /*HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.4.159:8080/ApiServer/Certificato/write");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }*/
        }
    }
}
