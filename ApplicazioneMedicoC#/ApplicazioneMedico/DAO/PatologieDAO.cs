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
    public class PatologieDAO : BaseDAO
    {
        public static DataTable GetDataTablePatologie()
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT cod_patologia, nome AS Nome, descrizione AS Descrizione ");
                sql.Append("FROM patologia ");

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
                throw new Exception("Impossibile recuperare le patologie", ex);
            }
            finally { cn.Close(); }
        }
    }
}
