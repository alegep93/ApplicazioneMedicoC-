using ApplicazioneMedico.DAO;
using ApplicazioneMedico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.API
{
    public class SyncDataFromServer : ApiRestClient
    {
        public static bool Synchronize(RootObject<Paziente> roPaz, RootObject<Patologia> roPat, RootObject<Certificato> roCert)
        {
            bool isSyncPazienti = SynchronizePazienti(roPaz);
            bool isSyncPatologie = SynchronizePatologie(roPat);
            bool isSyncCertificati = SynchronizeCertificati(roCert);

            return isSyncPazienti && isSyncPatologie && isSyncCertificati;
        }
        public static bool SynchronizePazienti(RootObject<Paziente> roPaz)
        {
            if (roPaz != null)
            {
                List<Paziente> pList = roPaz.data;

                try
                {
                    foreach (Paziente p in pList)
                    {
                        if (!PazientiDAO.PazienteExist(p.cod_sanitario))
                            PazientiDAO.InsertPaziente(p);
                        else
                            PazientiDAO.UpdatePaziente(p);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile eseguire la sincronizzazione della lista dei pazienti", ex);
                }
            }
            else
            {
                return false;
            }
        }
        public static bool SynchronizePatologie(RootObject<Patologia> roPat)
        {
            if (roPat != null)
            {
                List<Patologia> pList = roPat.data;

                try
                {
                    foreach (Patologia p in pList)
                    {
                        if (!PatologieDAO.PatologiaExist(p.cod_patologia))
                            PatologieDAO.InsertPatologia(p);
                        else
                            PatologieDAO.UpdatePatologia(p);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile eseguire la sincronizzazione della lista delle patologie", ex);
                }
            }
            else
            {
                return false;
            }
        }
        public static bool SynchronizeCertificati(RootObject<Certificato> roCert)
        {
            if (roCert != null)
            {
                List<Certificato> cList = roCert.data;

                try
                {
                    foreach (Certificato c in cList)
                    {
                        if (!CertificatiDAO.CertificatoExist(c.idCertificato))
                            CertificatiDAO.InsertCertificato(c);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile eseguire la sincronizzazione della lista dei certificati", ex);
                }
            }
            else
            {
                return false;
            }
        }
    }
}
