using ApplicazioneMedico.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.DAO
{
    public class PazientiDAO : BaseDAO
    {
        public static DataTable GetDataTablePazienti()
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT id,nome AS Nome,cognome AS Cognome,data_nascita AS 'Data Nascita',luogo AS 'Luogo di nascita',cod_fis AS 'Codice Fiscale', ");
                sql.Append("residenza AS Residenza,provincia AS Provincia,indirizzo AS Indirizzo,telefono AS Telefono,mobile AS Cellulare, ");
                sql.Append("email AS Email, cod_sanitario AS 'Codice Sanitario', cod_medico, data_update, data_inserimento ");
                sql.Append("FROM paziente ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare i pazienti", ex);
            }
            finally { cn.Close(); }
        }
    }
}
