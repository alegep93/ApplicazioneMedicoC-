using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.Data
{
    public class Certificato
    {
        int id;
        string codPaziente, codMedico, codPatologia, note;
        DateTime dataEmissione, dataInizio, dataFine;

        public Certificato()
        {
            this.Id = -1;
            this.CodPaziente = this.CodMedico = this.CodPatologia = this.Note = "";
            this.DataEmissione = this.DataInizio = this.DataFine = new DateTime();
        }

        public Certificato(int id, string codPaziente, string codMedico, string codPatologia, string note, DateTime dataEmissione, DateTime dataInizio, DateTime dataFine)
        {
            this.Id = id;
            this.CodPaziente = codPaziente;
            this.CodMedico = codMedico;
            this.CodPatologia = codPatologia;
            this.Note = note;
            this.DataEmissione = dataEmissione;
            this.DataInizio = dataInizio;
            this.DataFine = dataFine;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string CodPaziente
        {
            get
            {
                return codPaziente;
            }

            set
            {
                codPaziente = value;
            }
        }

        public string CodMedico
        {
            get
            {
                return codMedico;
            }

            set
            {
                codMedico = value;
            }
        }

        public string CodPatologia
        {
            get
            {
                return codPatologia;
            }

            set
            {
                codPatologia = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public DateTime DataEmissione
        {
            get
            {
                return dataEmissione;
            }

            set
            {
                dataEmissione = value;
            }
        }

        public DateTime DataInizio
        {
            get
            {
                return dataInizio;
            }

            set
            {
                dataInizio = value;
            }
        }

        public DateTime DataFine
        {
            get
            {
                return dataFine;
            }

            set
            {
                dataFine = value;
            }
        }
    }
}
