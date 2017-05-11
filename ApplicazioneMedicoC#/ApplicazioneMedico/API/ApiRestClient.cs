using ApplicazioneMedico.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.API
{
    public class ApiRestClient : JSONManager
    {
        private static WebClient syncClient = new WebClient();

        public static List<Paziente> GetListPazienti()
        {
            string url = "http://192.168.4.159:8080/ApiServer/Paziente/all/1";
            string jsonPazienti = syncClient.DownloadString(url);

            List<Paziente> listaPaz = DeserializeJson<List<Paziente>>(jsonPazienti);

            return listaPaz;
        }
        public static string GetServerDate()
        {
            string url = "http://192.168.4.159:8080/ApiServer/getTime";
            string sDate = syncClient.DownloadString(url);

            ServerDate date = DeserializeJson<ServerDate>(sDate);

            return date.now;
        }
    }
}
