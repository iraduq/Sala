using System;
using System.Collections.Generic;

namespace SalaDeFitness.LibrarieModele
{
    public class Abonament
    {
        public string Tip { get; set; }
        public decimal PretLunar { get; set; }

        public Abonament(string tip, decimal pretLunar)
        {
            Tip = tip;
            PretLunar = pretLunar;
        }

        public decimal CalculeazaPret(int nrLuni)
        {
            if (nrLuni <= 0 || nrLuni > 12)
            {
                throw new ArgumentException("Numarul de luni trebuie sa fie intre 1 si 12.");
            }
            return PretLunar * nrLuni;
        }

        public string AfiseazaDetalii(int nrLuni)
        {
            return $"Tip: {Tip}, Pret lunar: {PretLunar} RON, Durata: {nrLuni} luni, Total: {CalculeazaPret(nrLuni)} RON";
        }

        public static List<Abonament> TipuriAbonamente = new List<Abonament>
        {
            new Abonament("Basic", 100),
            new Abonament("Standard", 250),
            new Abonament("Premium", 400),
            new Abonament("VIP", 700),
            new Abonament("Student", 150),
            new Abonament("Corporate", 500),
            new Abonament("Senior", 200),
            new Abonament("Family", 800)
        };
    }
}