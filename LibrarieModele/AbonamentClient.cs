using System;

namespace SalaDeFitness.LibrarieModele
{
    public class AbonamentClient
    {
        public Abonament Abonament { get; set; }
        public int NrLuni { get; set; }
        public DateTime DataInceperii { get; set; }
        public DateTime DataExpirarii { get; set; }
        public Antrenor Antrenor { get; set; }

        public Client Client { get; set; }

        public AbonamentClient(Abonament abonament, int nrLuni, DateTime dataInceperii, Antrenor antrenor, Client client)
        {
            if (nrLuni <= 0 || nrLuni > 12)
            {
                throw new ArgumentException("Numarul de luni trebuie sa fie intre 1 si 12.");
            }

            Abonament = abonament;
            NrLuni = nrLuni;
            DataInceperii = dataInceperii;
            DataExpirarii = dataInceperii.AddMonths(nrLuni);
            Antrenor = antrenor;
            Client = client;
        }

        public string AfiseazaDetalii()
        {
            return $"{Abonament.AfiseazaDetalii(NrLuni)}, Incepe: {DataInceperii.ToShortDateString()}, Expira: {DataExpirarii.ToShortDateString()}, Antrenor: {Antrenor.Nume} {Antrenor.Prenume}";
        }
    }
}