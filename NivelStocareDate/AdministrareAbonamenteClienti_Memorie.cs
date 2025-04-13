using System.Collections.Generic;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAbonamenteClienti_Memorie
    {
        private List<AbonamentClient> abonamenteClienti;

        public AdministrareAbonamenteClienti_Memorie()
        {
            abonamenteClienti = new List<AbonamentClient>();
        }

        public void AddAbonamentClient(AbonamentClient abonamentClient)
        {
            abonamenteClienti.Add(abonamentClient);
        }

        public List<AbonamentClient> GetAbonamenteClienti()
        {
            return abonamenteClienti;
        }
    }
}