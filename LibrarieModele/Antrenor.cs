using SalaDeFitness.LibrarieModele;
using System.Text;

namespace SalaDeFitness.LibrarieModele
{
    public class Antrenor : Persoana
    {

        public string Specializare { get; set; }

        public Antrenor(string nume, string prenume, string cnp, string email, string numarTelefon, string specializare)
            : base(nume, prenume, cnp, email, numarTelefon)
        {
            Specializare = specializare;
        }

        // Override pentru a se face diferenta dintre metoda AfiseazaDetalii() din Antrenor si AfiseazaDetalii() din alte clase
        public override string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Detalii Antrenor:");
            sb.Append(base.AfiseazaDetalii());
            sb.AppendLine($"Specializare: {Specializare}");
            return sb.ToString();
        }
    }

}


