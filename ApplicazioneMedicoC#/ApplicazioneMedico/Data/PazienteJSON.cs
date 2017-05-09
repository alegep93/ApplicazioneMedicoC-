using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.Data
{
    [DataContract]
    class PazienteJSON
    {
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string cognome { get; set; }
        [DataMember]
        public string data_nascita { get; set; }
        [DataMember]
        public string luogo { get; set; }
        [DataMember]
        public string cod_fis { get; set; }
        [DataMember]
        public string residenza { get; set; }
        [DataMember]
        public string provincia { get; set; }
        [DataMember]
        public string indirizzo { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public string mobile { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string cod_sanitario { get; set; }
        [DataMember]
        public string cod_medico { get; set; }
    }
}
