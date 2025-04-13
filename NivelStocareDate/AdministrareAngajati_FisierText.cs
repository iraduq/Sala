using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAngajati_FisierText
    {
        private enum IndexAngajat
        {
            ID = 0,         
            Nume = 1,
            Prenume = 2,
            CNP = 3,
            Email = 4,
            NumarTelefon = 5,
            Functie = 6,
        }


        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private readonly string fisierAngajati;

        public AdministrareAngajati_FisierText(string numeFisier)
        {
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            this.fisierAngajati = Path.Combine(locatieFisierSolutie, numeFisier);
            Stream streamFisierText = File.Open(fisierAngajati, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddAngajat(Angajat angajat)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(fisierAngajati, true))
            {
                streamWriterFisierText.WriteLine(ConversieLaSir_PentruFisier(angajat));
            }
        }


        public List<Angajat> GetAngajati()
        {
            List<Angajat> angajati = new List<Angajat>();

            using (StreamReader streamReader = new StreamReader(fisierAngajati))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    angajati.Add(ConversieAngajat_DinSirFisier(linieFisier));
                }
            }

            return angajati;
        }

        public bool DeleteAngajat(string cnp)
        {
            List<Angajat> angajati = GetAngajati();
            bool gasit = false;

            angajati.RemoveAll(a =>
            {
                if (a.CNP == cnp)
                {
                    gasit = true;
                    return true;
                }
                return false;
            });

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierAngajati, false))
                {
                    foreach (var angajat in angajati)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(angajat));
                    }
                }
            }

            return gasit;
        }

        public bool UpdateAngajat(Angajat angajatActualizat)
        {
            List<Angajat> angajati = GetAngajati();
            bool gasit = false;

            for (int i = 0; i < angajati.Count; i++)
            {
                if (angajati[i].CNP == angajatActualizat.CNP)
                {
                    angajati[i] = angajatActualizat;
                    gasit = true;
                    break;
                }
            }

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierAngajati, false))
                {
                    foreach (var angajat in angajati)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(angajat));
                    }
                }
            }

            return gasit;
        }

        public List<Angajat> SearchAngajati(string searchText)
        {
            List<Angajat> totiAngajatii = GetAngajati();

            if (string.IsNullOrEmpty(searchText))
            {
                return totiAngajatii;
            }

            return totiAngajatii
                .Where(angajat => angajat.Nume != null &&
                                  angajat.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }


        private string ConversieLaSir_PentruFisier(Angajat angajat)
        {
            return $"{angajat.Id}{SEPARATOR_PRINCIPAL_FISIER}" +  
                   $"{angajat.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.Prenume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.CNP}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.Email}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.NumarTelefon}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.Functie}{SEPARATOR_PRINCIPAL_FISIER}" 
                  ;  
        }


        private Angajat ConversieAngajat_DinSirFisier(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            if (!Guid.TryParse(dateFisier[(int)IndexAbonamentClient.ID], out Guid id))
            {
                throw new ArgumentException($"Id-ul (GUID) nu este valid: {dateFisier[(int)IndexAbonamentClient.ID]}");
            }

            string Nume = dateFisier[(int)IndexAngajat.Nume];
            string Prenume = dateFisier[(int)IndexAngajat.Prenume];
            string CNP = dateFisier[(int)IndexAngajat.CNP];
            string Email = dateFisier[(int)IndexAngajat.Email];
            string NumarTelefon = dateFisier[(int)IndexAngajat.NumarTelefon];
            string Functie = dateFisier[(int)IndexAngajat.Functie];

            Angajat angajat = new Angajat(Nume, Prenume, CNP, Email, NumarTelefon, Functie)
            {
                Id = id
            };

            return angajat;
        }
    }
}
