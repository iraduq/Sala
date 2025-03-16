using System.Linq;
using System.Text;
using System;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.LibrarieModele
{
    public class Persoana
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string Email { get; set; }
        public string NumarTelefon { get; set; }

        public Persoana(string nume, string prenume, string cnp, string email, string numarTelefon)
        {
            if (cnp.Length != 13)
            {
                throw new ArgumentException("CNP-ul trebuie sa aiba 13 caractere.");
            }

            if (string.IsNullOrEmpty(nume))
            {
                throw new ArgumentException("Numele nu poate fi empty.");
            }

            if (string.IsNullOrEmpty(prenume))
            {
                throw new ArgumentException("Prenumele nu poate fi empty.");
            }

            Validare validare = new Validare();

           
            bool isValid = validare.ValidareEmail(email);

            if (isValid == false)
            {
                throw new ArgumentException("Format email gresit");
            }



            if (ValidareNumar.ValidareNumarTelefon(numarTelefon) != true)

            {
                throw new ArgumentException("Numarul de telefon nu are formattul corect ");
            }

            Nume = nume;
            Prenume = prenume;
            CNP = cnp;
            Email = email;
            NumarTelefon = numarTelefon;
        }

       


        

        public virtual string AfiseazaDetalii()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nume: {Nume} {Prenume}");
            sb.AppendLine($"CNP: {CNP}");
            sb.AppendLine($"Email: {Email}");
            sb.AppendLine($"Telefon: {NumarTelefon}");
            return sb.ToString();
        }
    }
}
