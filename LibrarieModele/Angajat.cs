using System;
using System.Text;

namespace SalaDeFitness.LibrarieModele
{
    public class Angajat : Persoana
    {
        public Guid Id { get; set; }
        public string Functie { get; set; }
        public string DisplayText
        {
            get
            {
                return $"{Nume} {Prenume} - {Functie}";
            }
        }

        public Angajat(string nume, string prenume, string cnp, string email, string numarTelefon, string functie)
            : base(nume, prenume, cnp, email, numarTelefon)
        {
            Id = Guid.NewGuid();
            Functie = functie;
        }

      
        public override string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Detalii Antrenor:");
            sb.AppendLine($"ID: {Id}");
            sb.Append(base.AfiseazaDetalii());
            sb.AppendLine($"Functie: {Functie}");
            return sb.ToString();
        }
    }
}
