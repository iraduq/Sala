using System.Collections.Generic;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAngajati_Memorie
    {
        private List<Angajat> angajati;

        public AdministrareAngajati_Memorie()
        {
            angajati = new List<Angajat>();
        }

        public void AddAngajat(Angajat angajat)
        {
            angajati.Add(angajat);
        }

        public List<Angajat> GetAngajati()
        {
            return angajati;
        }
    }
}