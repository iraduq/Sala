using System;
using System.Collections.Generic;
using System.IO;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAngajati_FisierText
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private readonly string fisierAngajati;

        private const int INDEX_NUME = 0;
        private const int INDEX_PRENUME = 1;
        private const int INDEX_CNP = 2;
        private const int INDEX_EMAIL = 3;
        private const int INDEX_NUMAR_TELEFON = 4;
        private const int INDEX_FUNCTIE = 5;  
        private const int INDEX_ROL = 6;

        public AdministrareAngajati_FisierText(string numeFisier)
        {
            this.fisierAngajati = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
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
            List<Angajat> angajatiGasiti = new List<Angajat>();

            if (string.IsNullOrEmpty(searchText))
            {
                return totiAngajatii;
            }

            foreach (var angajat in totiAngajatii)
            {
                if ((angajat.Nume != null && angajat.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (angajat.Prenume != null && angajat.Prenume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (angajat.CNP != null && angajat.CNP.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (angajat.Email != null && angajat.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (angajat.NumarTelefon != null && angajat.NumarTelefon.IndexOf(searchText) >= 0) ||
                    (angajat.Functie != null && angajat.Functie.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0))  
                {
                    angajatiGasiti.Add(angajat);
                }
            }

            return angajatiGasiti;
        }

        private string ConversieLaSir_PentruFisier(Angajat angajat)
        {
            return $"{angajat.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.Prenume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.CNP}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.Email}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.NumarTelefon}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{angajat.Functie}{SEPARATOR_PRINCIPAL_FISIER}";
               
        }

        private Angajat ConversieAngajat_DinSirFisier(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            string Nume = dateFisier[INDEX_NUME];
            string Prenume = dateFisier[INDEX_PRENUME];
            string CNP = dateFisier[INDEX_CNP];
            string Email = dateFisier[INDEX_EMAIL];
            string NumarTelefon = dateFisier[INDEX_NUMAR_TELEFON];
            string Functie = dateFisier[INDEX_FUNCTIE];  
            string Rol = dateFisier[INDEX_ROL];

            Angajat angajat = new Angajat(Nume, Prenume, CNP, Email, NumarTelefon, Functie); 

            return angajat;
        }
    }
}
