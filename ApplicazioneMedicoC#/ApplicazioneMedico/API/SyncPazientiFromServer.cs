using ApplicazioneMedico.DAO;
using ApplicazioneMedico.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicazioneMedico.API
{
    public class SyncPazientiFromServer : ApiRestClient
    {
        public static bool Synchronize()
        {
            List<Paziente> pList = GetListPazienti();

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
    }
}
