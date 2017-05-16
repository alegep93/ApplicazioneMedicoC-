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
        public static Patologia GetPatologia(string codPat)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;
            Patologia p = new Patologia();

            try
            {
                sql.Append("SELECT * FROM patologia WHERE cod_patologia = @pCodPat ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPat", codPat));

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p.cod_patologia = dr.GetString(1);
                    p.nome = dr.GetString(2);
                    p.descrizione = dr.GetString(3);
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare la singola patologia", ex);
            }
            finally { cn.Close(); }
        }
        public static bool PatologiaExist(string codPat)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;

            try
            {
                sql.Append("SELECT * FROM patologia WHERE cod_patologia = @pCodPat ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPat", codPat));

                dr = cmd.ExecuteReader();

                if (dr.Read())
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile definire se la patologia esiste", ex);
            }
            finally { cn.Close(); }
        }
        public static void InsertPatologia(Patologia p)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("INSERT INTO patologia (cod_patologia, nome, descrizione) ");
                sql.Append("VALUES (@pCodPat, @pNome, @pDescrizione) ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPat", p.cod_patologia));
                cmd.Parameters.Add(new SqlParameter("pNome", p.nome));
                cmd.Parameters.Add(new SqlParameter("pDescrizione", p.descrizione));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile inserire la Patologia", ex);
            }
        }
        public static void UpdatePatologia(Patologia p)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("UPDATE patologia SET cod_patologia = @pCodPat, nome = @pNome, descrizione = @pDescrizione ");
                sql.Append("WHERE cod_patologia = @pCodPat ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPat", p.cod_patologia));
                cmd.Parameters.Add(new SqlParameter("pNome", p.nome));
                cmd.Parameters.Add(new SqlParameter("pDescrizione", p.descrizione));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile aggiornare la Patologia", ex);
            }
        }
        public static DataTable SearchPatologie(string filter)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            filter = "%" + filter + "%";

            try
            {
                sql.Append("SELECT cod_patologia, nome AS Nome, descrizione AS Descrizione ");
                sql.Append("FROM patologia ");
                sql.Append("WHERE nome LIKE @pFilter OR descrizione LIKE @pFilter ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pFilter", filter));

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);

                return table;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile cercare tra le patologie", ex);
            }
            finally { cn.Close(); }
        }
    }
}
