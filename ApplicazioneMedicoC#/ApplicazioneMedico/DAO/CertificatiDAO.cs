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
                sql.Append("JOIN patologia AS Pat ON (C.cod_patologia = pat.cod_patologia) ");

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
        public static bool CertificatoExist(string idCert)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;

            try
            {
                sql.Append("SELECT * FROM certificato WHERE id = @pIdCert ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pIdCert", idCert));

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
        public static void InsertCertificato(Certificato c)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("INSERT INTO certificato (cod_paziente, cod_medico, data_emissione, cod_patologia, data_inizio, data_fine, tipologia, comune, provincia, indirizzo, cap, domicilio, note) ");
                sql.Append("VALUES (@pCodPaz, @pCodMed, @pDataEmis, @pCodPat, @pDataInizio, @pDataFine, @pTipologia, @pComune, @pProvincia, @pIndirizzo, @pCap, @pDomicilio, @pNote ");

                SqlCommand cmd = new SqlCommand(sql.ToString(), cn);
                cmd.Parameters.Add(new SqlParameter("pCodPaz", c.cod_sanitario));
                cmd.Parameters.Add(new SqlParameter("pCodMed", c.cod_medico));
                cmd.Parameters.Add(new SqlParameter("pDataEmis", c.data_emissione));
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

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Impossibile inserire il certificato", ex);
            }
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

        /*public static Certificato GetCertificato(string codPaz)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();
            SqlDataReader dr = null;
            Certificato c = new Certificato();

            try
            {
                sql.Append("SELECT * FROM certificato WHERE cod_sanitario = @pCodPaz ");

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
                    p.cap = dr.GetString(10);
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
        }*/
        /*public static void UpdateCertificato(Certificato p)
        {
            SqlConnection cn = GetConnection();
            StringBuilder sql = new StringBuilder();

            try
            {
                sql.Append("UPDATE certificato SET nome = @pNome, cognome = @pCognome, sesso = @pSesso, data_nascita = @pDataNascita, ");
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
                cmd.Parameters.Add(new SqlParameter("pCap", p.cap));
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
                throw new Exception("Impossibile aggiornare il Certificato", ex);
            }
        }*/
    }
}
