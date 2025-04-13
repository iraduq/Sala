using System;

namespace SalaDeFitness.LibrarieModele
{
    public class AbonamentClient
    {
        public Guid Id { get;  set; }
        public Abonament Abonament { get; set; }
        public int NrLuni { get; set; }
        public DateTime DataInceperii { get; set; }
        public DateTime DataExpirarii { get; set; }
        public Antrenor Antrenor { get; set; }
        public string DisplayText
        {
            get
            {
                return $"{Client.Nume} {Client.Prenume} - {Abonament.Tip} ({NrLuni} luni) - {DataExpirarii.ToString("d")} - Antrenor: {Antrenor.Nume} {Antrenor.Prenume}";
            }
        }



        public Client Client { get; set; }

        public AbonamentClient(Abonament abonament, int nrLuni, DateTime dataInceperii, Antrenor antrenor, Client client)
        {
            if (nrLuni <= 0 || nrLuni > 12)
            {
                throw new ArgumentException("Numarul de luni trebuie sa fie intre 1 si 12.");
            }
            Id = Guid.NewGuid();
            Abonament = abonament;
            NrLuni = nrLuni;
            DataInceperii = dataInceperii;
            DataExpirarii = dataInceperii.AddMonths(nrLuni);
            Antrenor = antrenor;
            Client = client;
        }

        public string AfiseazaDetalii()
        {
            return $"ID: {Id}\n" +
                   $"Tip Abonament: {Abonament.Tip}\n" +
                   $"Pret Lunar: {Abonament.PretLunar} RON\n" +
                   $"Luni: {NrLuni}\n" +
                   $"Incepe: {DataInceperii.ToShortDateString()}\n" +
                   $"Expira: {DataExpirarii.ToShortDateString()}\n" +
                   $"Antrenor: {Antrenor.Nume}\n" +
                   $"Client: {Client.Nume}";
        }


    }
}