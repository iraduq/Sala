using System;
using System.Text;

namespace SalaDeFitness.LibrarieModele
{
    public class Angajat : Persoana
    {
        public string Functie { get; set; }

        public Angajat(string nume, string prenume, string cnp, string email, string numarTelefon, string functie)
            : base(nume, prenume, cnp, email, numarTelefon)
        {
            Functie = functie;
        }

        public override string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Detalii Angajat:");
            sb.Append(base.AfiseazaDetalii());
            sb.AppendLine($"Functie: {Functie}");
            return sb.ToString();
        }
    }
}
