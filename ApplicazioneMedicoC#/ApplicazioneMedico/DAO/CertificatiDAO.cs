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
    public class CertificatiDAO : BaseDAO
    {
        public static DataTable GetDataTableCertificati()
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT C.id, P.nome + ' ' + P.cognome AS 'Nominativo Paziente', C.data_emissione AS 'Data Emissione', ");
                sql.Append("pat.nome AS 'Patologia', C.data_inizio AS 'Data Inizio', C.data_fine AS 'Data Fine', C.tipologia AS Tipologia, C.comune AS Comune, ");
                sql.Append("C.provincia AS Provincia, C.indirizzo AS Indirizzo, C.cap AS Cap, C.domicilio AS Domicilio, C.note AS Note ");
                sql.Append("FROM certificato AS C JOIN paziente AS P ON (C.cod_paziente = P.cod_sanitario) ");
                sql.Append("JOIN patologia AS Pat ON (C.cod_patologia = Pat.cod_patologia) ");
                sql.Append("ORDER BY data_emissione DESC ");

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
        public static List<Certificato> GetListCertificati()
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr;
            List<Certificato> cList = new List<Certificato>();

            try
            {
                sql.Append("SELECT [id], [cod_paziente], [cod_medico], [data_emissione], [cod_patologia], [data_inizio], [data_fine], ");
                sql.Append("[tipologia], [comune], [provincia], [indirizzo], [cap], [domicilio], [note] ");
                sql.Append("FROM certificato ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Certificato c = new Certificato();
                    c.idCertificato = dr.GetString(0);
                    c.cod_sanitario = dr.GetString(1);
                    c.cod_medico = dr.GetString(2);
                    c.data_emissione = dr.GetString(3);
                    c.cod_patologia = dr.GetString(4);
                    c.data_inizio = dr.GetString(5);
                    c.data_fine = dr.GetString(6);
                    c.tipologia = dr.GetString(7);
                    c.comune = dr.GetString(8);
                    c.provincia = dr.GetString(9);
                    c.indirizzo = dr.GetString(10);
                    c.CAP = dr.GetString(11);
                    c.domicilio = dr.GetString(12);
                    c.note = dr.GetString(13);
                    
                    cList.Add(c);
                }

                return cList;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare i certificati", ex);
            }
            finally { cn.Close(); }
        }
        public static List<Certificato> GetListCertificatiAfterSyncDate()
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr;
            List<Certificato> cList = new List<Certificato>();

            try
            {
                sql.Append("SELECT [id], [cod_paziente], [cod_medico], [data_emissione], [cod_patologia], [data_inizio], [data_fine], ");
                sql.Append("[tipologia], [comune], [provincia], [indirizzo], [cap], [domicilio], [note] ");
                sql.Append("FROM certificato ");
                sql.Append("WHERE data_emissione > @pLastSyncDate");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pLastSyncDate", MedicoDAO.GetLastSyncDate()));
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Certificato c = new Certificato();
                    c.idCertificato = dr.GetInt32(0).ToString();
                    c.cod_sanitario = dr.GetString(1);
                    c.cod_medico = dr.GetString(2);
                    c.data_emissione = dr.GetDateTime(3).ToString();
                    c.cod_patologia = dr.GetString(4);
                    c.data_inizio = dr.GetDateTime(5).ToString();
                    c.data_fine = dr.GetDateTime(6).ToString();
                    c.tipologia = dr.GetString(7);
                    c.comune = dr.GetString(8);
                    c.provincia = dr.GetString(9);
                    c.indirizzo = dr.GetString(10);
                    c.CAP = dr.GetString(11);
                    c.domicilio = dr.GetString(12);
                    c.note = dr.GetString(13);

                    cList.Add(c);
                }

                return cList;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare i certificati", ex);
            }
            finally { cn.Close(); }
        }
        public static bool CertificatoExist(string idCert)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;

            try
            {
                sql.Append("SELECT * FROM certificato WHERE id = @pIdCert AND cod_medico = @pCodMed ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pIdCert", idCert));
                cmd.Parameters.Add(new SqlParameter("pCodMed", ConfigManager.GetCodiceMedico()));

                dr = cmd.ExecuteReader();

                if (dr.Read())
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile recuperare i certificati", ex);
            }
            finally { cn.Close(); }
        }
        public static bool InsertCertificato(Certificato c)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("INSERT INTO certificato (cod_paziente, cod_medico, data_emissione, cod_patologia, data_inizio, data_fine, tipologia, comune, provincia, indirizzo, cap, domicilio, note) ");
                sql.Append("VALUES (@pCodPaz, @pCodMed, @pDataEmis, @pCodPat, @pDataInizio, @pDataFine, @pTipologia, @pComune, @pProvincia, @pIndirizzo, @pCap, @pDomicilio, @pNote) ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPaz", c.cod_sanitario));
                cmd.Parameters.Add(new SqlParameter("pCodMed", c.cod_medico));
                cmd.Parameters.Add(new SqlParameter("pDataEmis", Convert.ToDateTime(c.data_emissione)));
                cmd.Parameters.Add(new SqlParameter("pCodPat", c.cod_patologia));
                cmd.Parameters.Add(new SqlParameter("pDataInizio", c.data_inizio));
                cmd.Parameters.Add(new SqlParameter("pDataFine", c.data_fine));
                cmd.Parameters.Add(new SqlParameter("pTipologia", c.tipologia));
                cmd.Parameters.Add(new SqlParameter("pComune", c.comune));
                cmd.Parameters.Add(new SqlParameter("pProvincia", c.provincia));
                cmd.Parameters.Add(new SqlParameter("pIndirizzo", c.indirizzo));
                cmd.Parameters.Add(new SqlParameter("pCap", c.CAP));
                cmd.Parameters.Add(new SqlParameter("pDomicilio", c.domicilio));
                cmd.Parameters.Add(new SqlParameter("pNote", c.note));

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile inserire il certificato", ex);
            }
        }
        public static DataTable GetCertificatiSingoloPaziente(string codPaz)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("SELECT C.id, C.data_emissione AS 'Data Emissione', ");
                sql.Append("pat.nome AS 'Patologia', C.data_inizio AS 'Data Inizio', C.data_fine AS 'Data Fine', C.tipologia AS Tipologia, C.comune AS Comune, ");
                sql.Append("C.provincia AS Provincia, C.indirizzo AS Indirizzo, C.cap AS Cap, C.domicilio AS Domicilio, C.note AS Note ");
                sql.Append("FROM certificato AS C JOIN paziente AS P ON (C.cod_paziente = P.cod_sanitario) ");
                sql.Append("JOIN patologia AS Pat ON (C.cod_patologia = pat.cod_patologia) ");
                sql.Append("WHERE cod_paziente = @pCodPaz ");
                sql.Append("ORDER BY data_emissione DESC ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPaz", codPaz));
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
        public static bool DeleteCertificatiNonInviati(string idCert)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("DELETE certificato WHERE id = @pId");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pId", idCert));

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile eliminare il certificato non ancora inviato", ex);
            }finally { cn.Close(); }
        }
        public static DataTable SearchCertificati(string filter)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            filter = "%" + filter + "%";

            try
            {
                sql.Append("SELECT C.id, P.nome + ' ' + P.cognome AS 'Nominativo Paziente', C.data_emissione AS 'Data Emissione', ");
                sql.Append("Pat.nome AS 'Patologia', C.data_inizio AS 'Data Inizio', C.data_fine AS 'Data Fine', C.tipologia AS Tipologia, C.comune AS Comune, ");
                sql.Append("C.provincia AS Provincia, C.indirizzo AS Indirizzo, C.cap AS Cap, C.domicilio AS Domicilio, C.note AS Note ");
                sql.Append("FROM certificato AS C JOIN paziente AS P ON (C.cod_paziente = P.cod_sanitario) ");
                sql.Append("JOIN patologia AS Pat ON (C.cod_patologia = Pat.cod_patologia) ");
                sql.Append("WHERE P.nome LIKE @pFilter OR P.cognome LIKE @pFilter OR Pat.nome LIKE @pFilter OR C.tipologia LIKE @pFilter OR C.comune LIKE @pFilter ");
                sql.Append("OR C.provincia LIKE @pFilter OR C.indirizzo LIKE @pFilter OR C.cap LIKE @pFilter OR C.domicilio LIKE @pFilter OR C.note LIKE @pFilter ");

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

        public static DataTable SearchPazienti(string filter)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            filter = "%" + filter + "%";

            try
            {
                sql.Append("SELECT C.id, P.nome + ' ' + P.cognome AS 'Nominativo Paziente', C.data_emissione, Pat.nome, ");
                sql.Append("C.data_inizio, C.data_fine, C.tipologia AS Tipologia, C.comune AS Comune, ");
                sql.Append("C.provincia AS Provincia, C.indirizzo AS Indirizzo, C.cap AS Cap, C.domicilio AS Domicilio, C.note ");
                sql.Append("FROM certificato AS C ");
                sql.Append("JOIN paziente AS P ON (C.cod_paziente = P.cod_sanitario) ");
                sql.Append("JOIN patologia AS Pat ON(C.cod_patologia = Pat.cod_patologia) ");
                sql.Append("WHERE P.nome LIKE @pFilter OR P.cognome LIKE @pFilter OR C.data_emissione LIKE @pFilter OR ");
                sql.Append("Pat.nome LIKE @pFilter OR C.data_inizio LIKE @pFilter OR C.data_fine LIKE @pFilter OR tipologia LIKE @pFilter OR ");
                sql.Append("comune LIKE @pFilter OR provincia LIKE @pFilter OR indirizzo LIKE @pFilter OR cap LIKE @pFilter OR domicilio LIKE @pFilter OR C.note LIKE @pFilter ");

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
                throw new Exception("Impossibile recuperare i certificati", ex);
            }
            finally { cn.Close(); }
        }
    }
}
