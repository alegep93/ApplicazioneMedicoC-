using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.Data
{
    public class ServerDate
    {
        [DataMember]
        public string now { get; set; }
    }
}
