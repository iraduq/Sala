using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareAntrenori_FisierText
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private readonly string fisierAntrenori;


        private enum IndexCamps
        {
            ID = 0,         
            NUME = 1,
            PRENUME = 2,
            CNP = 3,
            EMAIL = 4,
            NUMAR_TELEFON = 5,
            SPECIALIZARE = 6
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

            if (string.IsNullOrEmpty(searchText))
            {
                return totiAntrenorii;
            }

            return totiAntrenorii
                .Where(antrenor => antrenor.Nume != null &&
                                   antrenor.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }


        private string ConversieLaSir_PentruFisier(Antrenor antrenor)
        {
            return $"{antrenor.Id}{SEPARATOR_PRINCIPAL_FISIER}" +  
                   $"{antrenor.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.Prenume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.CNP}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.Email}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.NumarTelefon}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{antrenor.Specializare}";
        }


        private Antrenor ConversieAntrenor_DinSirFisier(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            Guid id = Guid.Parse(dateFisier[(int)IndexCamps.ID]);  
            string Nume = dateFisier[(int)IndexCamps.NUME];
            string Prenume = dateFisier[(int)IndexCamps.PRENUME];
            string CNP = dateFisier[(int)IndexCamps.CNP];
            string Email = dateFisier[(int)IndexCamps.EMAIL];
            string NumarTelefon = dateFisier[(int)IndexCamps.NUMAR_TELEFON];
            string Specializare = dateFisier[(int)IndexCamps.SPECIALIZARE];

            Antrenor antrenor = new Antrenor(Nume, Prenume, CNP, Email, NumarTelefon, Specializare)
            {
                Id = id  
            };

            return antrenor;
        }

    }
}
