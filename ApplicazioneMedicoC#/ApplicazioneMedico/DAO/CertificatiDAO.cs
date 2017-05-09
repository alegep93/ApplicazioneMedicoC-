using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.DAO
{
    public class CertificatiDAO : BaseDAO
    {
        public static DataTable GetDataTableCertificati()
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT c.id,p.nome + ' ' + p.cognome AS 'Nominativo Paziente',c.cod_medico AS 'Codice Medico',c.data_emissione AS 'Data Emissione', ");
                sql.Append("c.cod_patologia AS 'Codice Patologia', c.data_inizio AS 'Data Inizio', c.data_fine AS 'Data Fine', c.note AS Note ");
                sql.Append("FROM certificato AS c JOIN Paziente AS p ON (c.cod_paziente = p.cod_sanitario) ");

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
                throw new Exception("Impossibile recuperare i certificati", ex);
            }
            finally { cn.Close(); }
        }
    }
}
