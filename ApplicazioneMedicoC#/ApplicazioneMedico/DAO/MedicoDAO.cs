using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.DAO
{
    public class MedicoDAO : BaseDAO
    {
        public static DateTime GetLastSyncDate()
        {
            DateTime lastUpdate = new DateTime();
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;

            try
            {
                sql.Append("SELECT data_ultimo_update FROM medico ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lastUpdate = dr.GetDateTime(0);
                }

                return lastUpdate;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare la data di ultimo update", ex);
            }
        }
        public static bool UpdateLastSyncDate(DateTime syncDate)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("UPDATE medico SET data_ultimo_update = @pDataUpdate ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pDataUpdate", syncDate));

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare la data di ultimo update", ex);
            }
        }
    }
}
