using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.Data
{
    [DataContract]
    public class Patologia : RootObject<Patologia>
    {
        [DataMember]
        public string codicePatologia { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string descrizione { get; set; }
    }
}
