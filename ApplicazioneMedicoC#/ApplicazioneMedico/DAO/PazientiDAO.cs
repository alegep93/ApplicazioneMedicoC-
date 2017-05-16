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
                sql.Append("SELECT id,nome AS Nome,cognome AS Cognome,sesso AS Sesso,data_nascita AS 'Data Nascita',luogo AS 'Luogo di nascita',cod_fis AS 'Codice Fiscale', ");
                sql.Append("residenza AS Residenza,provincia AS Provincia,indirizzo AS Indirizzo, cap AS Cap, telefono AS Telefono,mobile AS Cellulare, ");
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
        public static Paziente GetPaziente(string codSan)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;
            Paziente p = new Paziente();

            try
            {
                sql.Append("SELECT * FROM paziente WHERE cod_sanitario = @pCodSan ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodSan", codSan));

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p.nome = dr.GetString(1);
                    p.cognome = dr.GetString(2);
                    p.Sesso = dr.GetString(3);
                    p.data_nascita = dr.GetDateTime(4).ToString();
                    p.luogo = dr.GetString(5);
                    p.cod_fis = dr.GetString(6);
                    p.residenza = dr.GetString(7);
                    p.provincia = dr.GetString(8);
                    p.indirizzo = dr.GetString(9);
                    p.CAP = dr.GetString(10);
                    p.telefono = dr.GetString(11);
                    p.mobile = dr.GetString(12);
                    p.email = dr.GetString(13);
                    p.cod_sanitario = dr.GetString(14);
                    p.cod_medico = dr.GetString(15);
                    p.data_update = dr.GetDateTime(16).ToString();
                    p.data_inserimento = dr.GetDateTime(17).ToString();
                }

                return p;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare i pazienti", ex);
            }
            finally { cn.Close(); }
        }
        public static bool PazienteExist(string codSan)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;

            try
            {
                sql.Append("SELECT * FROM paziente WHERE cod_sanitario = @pCodSan ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodSan", codSan));

                dr = cmd.ExecuteReader();

                if (dr.Read())
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare i pazienti", ex);
            }
            finally { cn.Close(); }
        }
        public static void InsertPaziente(Paziente p)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("INSERT INTO paziente (nome, cognome, sesso, data_nascita, luogo, cod_fis, ");
                sql.Append("residenza, provincia, indirizzo, cap, telefono, mobile, ");
                sql.Append("email, cod_sanitario, cod_medico, data_update, data_inserimento) ");
                sql.Append("VALUES (@pNome, @pCognome, @pSesso, @pDataNascita, @pLuogo, @pCodFis, @pResidenza, @pProvincia, ");
                sql.Append("@pIndirizzo, @pCap, @pTelefono, @pMobile, @pEmail, @pCodSan, @pCodMed, @pDataUpdate, @pDataInserimento) ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pNome", p.nome));
                cmd.Parameters.Add(new SqlParameter("pCognome", p.cognome));
                cmd.Parameters.Add(new SqlParameter("pSesso", p.Sesso));
                cmd.Parameters.Add(new SqlParameter("pDataNascita", p.data_nascita));
                cmd.Parameters.Add(new SqlParameter("pLuogo", p.luogo));
                cmd.Parameters.Add(new SqlParameter("pCodFis", p.cod_fis));
                cmd.Parameters.Add(new SqlParameter("pResidenza", p.residenza));
                cmd.Parameters.Add(new SqlParameter("pProvincia", p.provincia));
                cmd.Parameters.Add(new SqlParameter("pIndirizzo", p.indirizzo));
                cmd.Parameters.Add(new SqlParameter("pCap", p.CAP));
                cmd.Parameters.Add(new SqlParameter("pTelefono", p.telefono));
                cmd.Parameters.Add(new SqlParameter("pMobile", p.mobile));
                cmd.Parameters.Add(new SqlParameter("pEmail", p.email));
                cmd.Parameters.Add(new SqlParameter("pCodSan", p.cod_sanitario));
                cmd.Parameters.Add(new SqlParameter("pCodMed", p.cod_medico));
                cmd.Parameters.Add(new SqlParameter("pDataUpdate", p.data_update));
                cmd.Parameters.Add(new SqlParameter("pDataInserimento", p.data_inserimento));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile inserire il paziente", ex);
            }
        }
        public static void UpdatePaziente(Paziente p)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("UPDATE paziente SET nome = @pNome, cognome = @pCognome, sesso = @pSesso, data_nascita = @pDataNascita, ");
                sql.Append("luogo = @pLuogo, cod_fis = @pCodFis, residenza = @pResidenza, provincia = @pProvincia, ");
                sql.Append("indirizzo = @pIndirizzo, cap = @pCap, telefono = @pTelefono, mobile = @pMobile, email = @pEmail, ");
                sql.Append("cod_sanitario = @pCodSan, cod_medico = @pCodMed, data_update = @pDataUpdate, data_inserimento = @pDataInserimento ");
                sql.Append("WHERE cod_sanitario = @pCodSan AND data_update < @pDataUpdate ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pNome", p.nome));
                cmd.Parameters.Add(new SqlParameter("pCognome", p.cognome));
                cmd.Parameters.Add(new SqlParameter("pSesso", p.Sesso));
                cmd.Parameters.Add(new SqlParameter("pDataNascita", p.data_nascita));
                cmd.Parameters.Add(new SqlParameter("pLuogo", p.luogo));
                cmd.Parameters.Add(new SqlParameter("pCodFis", p.cod_fis));
                cmd.Parameters.Add(new SqlParameter("pResidenza", p.residenza));
                cmd.Parameters.Add(new SqlParameter("pProvincia", p.provincia));
                cmd.Parameters.Add(new SqlParameter("pIndirizzo", p.indirizzo));
                cmd.Parameters.Add(new SqlParameter("pCap", p.CAP));
                cmd.Parameters.Add(new SqlParameter("pTelefono", p.telefono));
                cmd.Parameters.Add(new SqlParameter("pMobile", p.mobile));
                cmd.Parameters.Add(new SqlParameter("pEmail", p.email));
                cmd.Parameters.Add(new SqlParameter("pCodSan", p.cod_sanitario));
                cmd.Parameters.Add(new SqlParameter("pCodMed", p.cod_medico));
                cmd.Parameters.Add(new SqlParameter("pDataUpdate", p.data_update));
                cmd.Parameters.Add(new SqlParameter("pDataInserimento", p.data_inserimento));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile aggiornare il paziente", ex);
            }
        }
        public static DataTable SearchPazienti(string filter)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            filter = "%" + filter + "%";

            try
            {
                sql.Append("SELECT id,nome AS Nome,cognome AS Cognome,sesso AS Sesso,data_nascita AS 'Data Nascita',luogo AS 'Luogo di nascita',cod_fis AS 'Codice Fiscale', ");
                sql.Append("residenza AS Residenza,provincia AS Provincia,indirizzo AS Indirizzo,cap AS Cap, telefono AS Telefono,mobile AS Cellulare, ");
                sql.Append("email AS Email, cod_sanitario AS 'Codice Sanitario', cod_medico, data_update, data_inserimento ");
                sql.Append("FROM paziente ");
                sql.Append("WHERE nome LIKE @pFilter OR cognome LIKE @pFilter OR sesso LIKE @pFilter OR data_nascita LIKE @pFilter OR luogo LIKE @pFilter OR cod_fis LIKE @pFilter ");
                sql.Append("OR residenza LIKE @pFilter OR provincia LIKE @pFilter OR indirizzo LIKE @pFilter OR cap LIKE @pFilter OR telefono LIKE @pFilter OR mobile LIKE @pFilter ");
                sql.Append("OR email LIKE @pFilter OR cod_sanitario LIKE @pFilter ");

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
                throw new Exception("Impossibile recuperare i pazienti", ex);
            }
            finally { cn.Close(); }
        }
    }
}
