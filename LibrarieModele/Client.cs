using System.Linq;
using System.Text;
using System;
using SalaDeFitness.LibrarieModele;


namespace SalaDeFitness.LibrarieModele
{
    public class Client : Persoana
    {
        public AbonamentClient AbonamentClient { get; set; }
        public string Status { get; set; }

        public Client(string nume, string prenume, string cnp, string email, string numarTelefon)
            : base(nume, prenume, cnp, email, numarTelefon)
        {
            AbonamentClient = null; 
            Status = "Inactiv"; 
        }

        public override string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Detalii Client:");
            sb.Append(base.AfiseazaDetalii());

            if (AbonamentClient != null)
            {
                sb.AppendLine("Abonament:");
                sb.AppendLine(AbonamentClient.AfiseazaDetalii());
            }
            else
            {
                sb.AppendLine("Nu exista abonament activ.");
            }

            return sb.ToString();
        }
    }
}