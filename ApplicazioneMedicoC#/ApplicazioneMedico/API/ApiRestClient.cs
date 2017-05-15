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
            string url = "http://192.168.4.159:8080/ApiServer/Patologie";
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
            string url = "http://192.168.4.159:8080/ApiServer/Certificati";
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
    }
}
