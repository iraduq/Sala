using System.Linq;
using System.Text;
using System;
using SalaDeFitness.LibrarieModele;


namespace SalaDeFitness.LibrarieModele
{
    public class Client : Persoana
    {
        public Guid Id { get; set; }
        public AbonamentClient AbonamentClient { get; set; }
        public string Status { get; set; }

        public string DisplayText => $"{Nume} - {CNP}";
        public Client(string nume, string prenume, string cnp, string email, string numarTelefon)
            : base(nume, prenume, cnp, email, numarTelefon)
        {
            Id = Guid.NewGuid();
            AbonamentClient = null; 
            Status = "Inactiv"; 
        }

        public override string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID Client: {Id}");
            sb.Append(base.AfiseazaDetalii());

            if (AbonamentClient != null)
            {
                sb.AppendLine("Abonament:");
                sb.AppendLine(AbonamentClient.AfiseazaDetalii());
            }
            else
            {
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}