using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.DAO
{
    public class BaseDAO
    {
        public static object ConfigurationManager { get; private set; }

        public static SqlConnection GetConnection()
        {
            SqlConnection cn = null;
            try
            {
                string connectionString = "Integrated Security=true;Initial Catalog=project_work;Data Source=PC1963";
                cn = new SqlConnection(connectionString);
                cn.Open();
            }
            catch (Exception ex)
            {
                String msg = "Si è verificato un errore durante la creazione della connessione col DB";
                throw new Exception(msg, ex);
            }
            return cn;
        }
        /*public static string QuerySelect(string campi, string tabelle, string condizioni, string ordine)
        {
            string sql = "SELECT " + campi + " FROM " + tabelle;
            if(condizioni!= "")
                sql += " WHERE " + condizioni;
            if (ordine != "")
                sql += " ORDER BY " + ordine;

            return sql;
        }*/
    }
}
