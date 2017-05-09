using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.Data
{
    public class Paziente
    {
        int id;
        string nome, cognome, luogoNascita, codiceFiscale, residenza;
        string provincia, indirizzo, telefono, cellulare, email;
        string codiceSanitario, codiceMedico;
        DateTime dataNascita, dataUpdate, dataInserimento;

        public Paziente()
        {
            this.id = -1;
            this.nome = this.cognome = this.luogoNascita = this.codiceFiscale = this.residenza = "";
            this.provincia = this.indirizzo = this.telefono = this.cellulare = this.email = "";
            this.codiceSanitario = this.codiceMedico = "";
            this.dataNascita = this.dataUpdate = this.dataInserimento = new DateTime();
        }

        public Paziente(int id, string nome, string cognome, string luogoNascita, string codiceFiscale, string residenza, string provincia, string indirizzo, string telefono, string cellulare, string email, string codiceSanitario, string codiceMedico, DateTime dataNascita, DateTime dataUpdate, DateTime dataInserimento)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.luogoNascita = luogoNascita;
            this.codiceFiscale = codiceFiscale;
            this.residenza = residenza;
            this.provincia = provincia;
            this.indirizzo = indirizzo;
            this.telefono = telefono;
            this.cellulare = cellulare;
            this.email = email;
            this.codiceSanitario = codiceSanitario;
            this.codiceMedico = codiceMedico;
            this.dataNascita = dataNascita;
            this.dataUpdate = dataUpdate;
            this.dataInserimento = dataInserimento;
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

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Cognome
        {
            get
            {
                return cognome;
            }

            set
            {
                cognome = value;
            }
        }

        public string LuogoNascita
        {
            get
            {
                return luogoNascita;
            }

            set
            {
                luogoNascita = value;
            }
        }

        public string CodiceFiscale
        {
            get
            {
                return codiceFiscale;
            }

            set
            {
                codiceFiscale = value;
            }
        }

        public string Residenza
        {
            get
            {
                return residenza;
            }

            set
            {
                residenza = value;
            }
        }

        public string Provincia
        {
            get
            {
                return provincia;
            }

            set
            {
                provincia = value;
            }
        }

        public string Indirizzo
        {
            get
            {
                return indirizzo;
            }

            set
            {
                indirizzo = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Cellulare
        {
            get
            {
                return cellulare;
            }

            set
            {
                cellulare = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string CodiceSanitario
        {
            get
            {
                return codiceSanitario;
            }

            set
            {
                codiceSanitario = value;
            }
        }

        public string CodiceMedico
        {
            get
            {
                return codiceMedico;
            }

            set
            {
                codiceMedico = value;
            }
        }

        public DateTime DataNascita
        {
            get
            {
                return dataNascita;
            }

            set
            {
                dataNascita = value;
            }
        }

        public DateTime DataUpdate
        {
            get
            {
                return dataUpdate;
            }

            set
            {
                dataUpdate = value;
            }
        }

        public DateTime DataInserimento
        {
            get
            {
                return dataInserimento;
            }

            set
            {
                dataInserimento = value;
            }
        }
    }
}
