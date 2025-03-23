using System;
using System.Collections.Generic;
using System.IO;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAntrenori_FisierText
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private readonly string fisierAntrenori;


        private enum IndexCamps
        {
            NUME = 0,
            PRENUME = 1,
            CNP = 2,
            EMAIL = 3,
            NUMAR_TELEFON = 4,
            SPECIALIZARE = 5
        }

        public AdministrareAntrenori_FisierText(string numeFisier)
        {
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            this.fisierAntrenori = Path.Combine(locatieFisierSolutie, numeFisier);
            Stream streamFisierText = File.Open(fisierAntrenori, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddAntrenor(Antrenor antrenor)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(fisierAntrenori, true))
            {
                streamWriterFisierText.WriteLine(ConversieLaSir_PentruFisier(antrenor));
            }
        }


        public List<Antrenor> GetAntrenori()
        {
            List<Antrenor> antrenori = new List<Antrenor>();

            using (StreamReader streamReader = new StreamReader(fisierAntrenori))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    antrenori.Add(ConversieAntrenor_DinSirFisier(linieFisier));
                }
            }

            return antrenori;
        }

        public bool DeleteAntrenor(string cnp)
        {
            List<Antrenor> antrenori = GetAntrenori();
            bool gasit = false;

            antrenori.RemoveAll(a =>
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
                using (StreamWriter streamWriter = new StreamWriter(fisierAntrenori, false))
                {
                    foreach (var antrenor in antrenori)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(antrenor));
                    }
                }
            }

            return gasit;
        }

        public bool UpdateAntrenor(Antrenor antrenorActualizat)
        {
            List<Antrenor> antrenori = GetAntrenori();
            bool gasit = false;

            for (int i = 0; i < antrenori.Count; i++)
            {
                if (antrenori[i].CNP == antrenorActualizat.CNP)
                {
                    antrenori[i] = antrenorActualizat;
                    gasit = true;
                    break;
                }
            }

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierAntrenori, false))
                {
                    foreach (var antrenor in antrenori)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(antrenor));
                    }
                }
            }

            return gasit;
        }

        public List<Antrenor> SearchAntrenori(string searchText)
        {
            List<Antrenor> totiAntrenorii = GetAntrenori();
            List<Antrenor> antrenoriGasiti = new List<Antrenor>();

            if (string.IsNullOrEmpty(searchText))
            {
                return totiAntrenorii;
            }

            foreach (var antrenor in totiAntrenorii)
            {
                if ((antrenor.Nume != null && antrenor.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (antrenor.Prenume != null && antrenor.Prenume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (antrenor.CNP != null && antrenor.CNP.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (antrenor.Email != null && antrenor.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (antrenor.NumarTelefon != null && antrenor.NumarTelefon.IndexOf(searchText) >= 0) ||
                    (antrenor.Specializare != null && antrenor.Specializare.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    antrenoriGasiti.Add(antrenor);
                }
            }

            return antrenoriGasiti;
        }

        private string ConversieLaSir_PentruFisier(Antrenor antrenor)
        {
            return $"{antrenor.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.Prenume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.CNP}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.Email}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.NumarTelefon}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.Specializare}";
        }

        private Antrenor ConversieAntrenor_DinSirFisier(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            string Nume = dateFisier[(int)IndexCamps.NUME];
            string Prenume = dateFisier[(int)IndexCamps.PRENUME];
            string CNP = dateFisier[(int)IndexCamps.CNP];
            string Email = dateFisier[(int)IndexCamps.EMAIL];
            string NumarTelefon = dateFisier[(int)IndexCamps.NUMAR_TELEFON];
            string Specializare = dateFisier[(int)IndexCamps.SPECIALIZARE];

            Antrenor antrenor = new Antrenor(Nume, Prenume, CNP, Email, NumarTelefon, Specializare);

            return antrenor;
        }
    }
}
