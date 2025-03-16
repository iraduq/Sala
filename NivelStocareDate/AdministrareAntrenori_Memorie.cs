using System.Collections.Generic;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAntrenori_Memorie
    {
        private List<Antrenor> antrenori;

        public AdministrareAntrenori_Memorie()
        {
            antrenori = new List<Antrenor>();
        }

        public void AddAntrenor(Antrenor antrenor)
        {
            antrenori.Add(antrenor);
        }

        public List<Antrenor> GetAntrenori()
        {
            return antrenori;
        }
    }
}