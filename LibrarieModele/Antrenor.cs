using SalaDeFitness.LibrarieModele;
using System;
using System.Text;

namespace SalaDeFitness.LibrarieModele
{
    public class Antrenor : Persoana
    {
        public Guid Id { get; set; }

        public string Specializare { get; set; }
        public object ID { get; set; }
        public object Telefon { get; set; }
        public string DisplayText => $"{Nume} {Prenume} - {Specializare} - {Email}";

        public Antrenor(string nume, string prenume, string cnp, string email, string numarTelefon, string specializare)
            : base(nume, prenume, cnp, email, numarTelefon)
        {
            Id = Guid.NewGuid();
            Specializare = specializare;
        }

    
        public override string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Detalii Antrenor:");
            sb.AppendLine($"ID: {Id}");
            sb.Append(base.AfiseazaDetalii());
            sb.AppendLine($"Specializare: {Specializare}");
            return sb.ToString();
        }
    }

}


