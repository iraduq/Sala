using System;
using System.Collections.Generic;
using System.IO;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public enum IndexAbonamentClient
    {
        Abonament = 0,
        NrLuni = 1,
        DataInceperii = 2,
        DataExpirarii = 3,
        Antrenor = 4,
        NumeClient = 5
    }

    public class AdministrareAbonamenteClienti_FisierText
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private readonly string fisierAbonamente;

        public AdministrareAbonamenteClienti_FisierText(string numeFisier)
        {
            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            this.fisierAbonamente = Path.Combine(locatieFisierSolutie, numeFisier);
            Stream streamFisierText = File.Open(fisierAbonamente, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddAbonamentClient(AbonamentClient abonamentClient)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(fisierAbonamente, true))
            {
                streamWriterFisierText.WriteLine(ConversieLaSir_PentruFisier(abonamentClient));
            }
        }



        public List<AbonamentClient> GetAbonamenteClienti()
        {
            List<AbonamentClient> abonamenteClienti = new List<AbonamentClient>();

            using (StreamReader streamReader = new StreamReader(fisierAbonamente))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    abonamenteClienti.Add(ConversieAbonamentClient_DinSirFisier(linieFisier));
                }
            }

            return abonamenteClienti;
        }


        public bool DeleteAbonamentClient(string abonamentDetalii)
        {
            List<AbonamentClient> abonamenteClienti = GetAbonamenteClienti();
            bool gasit = false;

            abonamenteClienti.RemoveAll(a =>
            {
                if (a.Abonament.AfiseazaDetalii(a.NrLuni).Contains(abonamentDetalii))
                {
                    gasit = true;
                    return true;
                }
                return false;
            });

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierAbonamente, false))
                {
                    foreach (var abonament in abonamenteClienti)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(abonament));
                    }
                }
            }

            return gasit;
        }

        public bool UpdateAbonamentClient(AbonamentClient abonamentClientActualizat)
        {
            List<AbonamentClient> abonamenteClienti = GetAbonamenteClienti();
            bool gasit = false;

            for (int i = 0; i < abonamenteClienti.Count; i++)
            {
                if (abonamenteClienti[i].Abonament.AfiseazaDetalii(abonamenteClienti[i].NrLuni) == abonamentClientActualizat.Abonament.AfiseazaDetalii(abonamentClientActualizat.NrLuni))
                {
                    abonamenteClienti[i] = abonamentClientActualizat;
                    gasit = true;
                    break;
                }
            }

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierAbonamente, false))
                {
                    foreach (var abonament in abonamenteClienti)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(abonament));
                    }
                }
            }

            return gasit;
        }

        public List<AbonamentClient> SearchAbonamenteClienti(string searchText)
        {
            List<AbonamentClient> totiAbonamenteClienti = GetAbonamenteClienti();
            List<AbonamentClient> abonamenteGasite = new List<AbonamentClient>();

            if (string.IsNullOrEmpty(searchText))
            {
                return totiAbonamenteClienti;
            }

            foreach (var abonament in totiAbonamenteClienti)
            {
                if ((abonament.Abonament.Tip != null && abonament.Abonament.Tip.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                     (abonament.Abonament.PretLunar.ToString().IndexOf(searchText) >= 0) ||
                     (abonament.NrLuni.ToString().IndexOf(searchText) >= 0) ||
                     (abonament.DataInceperii.ToString().IndexOf(searchText) >= 0) ||
                     (abonament.DataExpirarii.ToString().IndexOf(searchText) >= 0) ||
                     (abonament.Antrenor.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    abonamenteGasite.Add(abonament);
                }

            }

            return abonamenteGasite;
        }

        private string ConversieLaSir_PentruFisier(AbonamentClient abonamentClient)
        {
            return $"{abonamentClient.Abonament.Tip}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.NrLuni}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.DataInceperii.ToShortDateString()}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.DataExpirarii.ToShortDateString()}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.Antrenor.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.Client.Nume}";
        }


        public AbonamentClient ConversieAbonamentClient_DinSirFisier(string linie)
        {
          

        
            string[] date = linie.Split(';');

            if (date.Length < 6)
            {
                throw new ArgumentException("Date insuficiente pentru abonament.");
            }


            int numarLuni = int.Parse(date[(int)IndexAbonamentClient.NrLuni]);
            DateTime dataIncepere = DateTime.Parse(date[(int)IndexAbonamentClient.DataInceperii]);
            DateTime dataExpirare = DateTime.Parse(date[(int)IndexAbonamentClient.DataExpirarii]);
            string numeAntrenor = date[(int)IndexAbonamentClient.Antrenor];
            string numeClient = date[(int)IndexAbonamentClient.NumeClient];


            AdministrareAntrenori_FisierText adminAntrenori = new AdministrareAntrenori_FisierText("antrenori.txt"); 
            List<Antrenor> antrenoriGasiti = adminAntrenori.SearchAntrenori(numeAntrenor);
            Antrenor antrenor = null;

            if (antrenoriGasiti.Count > 0)
            {
                antrenor = antrenoriGasiti[0]; 
            }
            else
            {
                throw new InvalidOperationException($"Antrenorul {numeAntrenor} nu a fost gasit.");
            }

       
            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText("clienti.txt"); 
            List<Client> clientiGasiti = adminClienti.SearchClienti(numeClient);
            Client client = null;

            if (clientiGasiti.Count > 0)
            {
                client = clientiGasiti[0]; 
            }
            else
            {
                throw new InvalidOperationException($"Clientul {numeClient} nu a fost gasit.");
            }

          
            Abonament abonamentNou = new Abonament("Tip Abonament", 50);  
            AbonamentClient abonamentClientNou = new AbonamentClient(abonamentNou, numarLuni, dataIncepere, antrenor, client);

            return abonamentClientNou;
        }





    }
}