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

        public static RootObject GetDataFromServer()
        {
            string url = "http://192.168.4.159:8080/ApiServer2/Paziente/all/1";
            string jsonPazienti = syncClient.DownloadString(url);

            RootObject json = DeserializeJson<RootObject>(jsonPazienti);

            return json;
        }

        //Sostituito perchè la data ora viene passata ad ogni chiamata al server
        //public static string GetServerDate()
        //{
        //    string url = "http://192.168.4.159:8080/ApiServer2/getTime";
        //    string sDate = syncClient.DownloadString(url);

        //    ServerDate date = DeserializeJson<ServerDate>(sDate);

        //    return date.now;
        //}
    }
}
