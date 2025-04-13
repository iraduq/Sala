using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public enum IndexAbonamentClient
    {
        ID = 0,
        NrLuni = 1,
        DataInceperii = 2,
        DataExpirarii = 3,
        Antrenor = 4,
        NumeClient = 5,
        Tip = 6
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
            try
            {
                using (StreamWriter streamWriterFisierText = new StreamWriter(fisierAbonamente, true))
                {
                    streamWriterFisierText.WriteLine(ConversieLaSir_PentruFisier(abonamentClient));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la scrierea in fisier: {ex.Message}");
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
                if (abonament.Client != null && abonament.Client.Nume != null &&
                    abonament.Client.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    abonamenteGasite.Add(abonament);
                }
            }

            return abonamenteGasite;
        }


        private string ConversieLaSir_PentruFisier(AbonamentClient abonamentClient)
        {
            return $"{abonamentClient.Id}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.NrLuni}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.DataInceperii.ToString("M/d/yyyy")}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.DataExpirarii.ToString("M/d/yyyy")}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.Antrenor.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentClient.Client.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +  
                   $"{abonamentClient.Abonament.Tip}";
        }

        public AbonamentClient ConversieAbonamentClient_DinSirFisier(string linie)
        {
  
            string[] date = linie.Split(SEPARATOR_PRINCIPAL_FISIER);

 
        
            if (!Guid.TryParse(date[(int)IndexAbonamentClient.ID], out Guid id))  
            {
                throw new ArgumentException($"Id-ul (GUID) nu este valid: {date[(int)IndexAbonamentClient.ID]}");
            }


            int numarLuni = int.Parse(date[(int)IndexAbonamentClient.NrLuni]);
            DateTime dataIncepere = DateTime.Parse(date[(int)IndexAbonamentClient.DataInceperii]);
            DateTime dataExpirare = DateTime.Parse(date[(int)IndexAbonamentClient.DataExpirarii]);
            string numeAntrenor = date[(int)IndexAbonamentClient.Antrenor];  
            string numeClient = date[(int)IndexAbonamentClient.NumeClient];  

   
            string tipAbonament = date[(int)IndexAbonamentClient.Tip];
            Abonament abonamentGasit = Abonament.TipuriAbonamente.FirstOrDefault(a => a.Tip.Equals(tipAbonament, StringComparison.OrdinalIgnoreCase));

            if (abonamentGasit == null)
            {
                throw new InvalidOperationException($"Tipul de abonament '{tipAbonament}' nu a fost gasit.");
            }


            AdministrareAntrenori_FisierText adminAntrenori = new AdministrareAntrenori_FisierText("antrenori.txt");
            List<Antrenor> antrenoriGasiti = adminAntrenori.SearchAntrenori(numeAntrenor);
            Antrenor antrenor = antrenoriGasiti.FirstOrDefault();

            if (antrenor == null)
            {
                throw new InvalidOperationException($"Antrenorul {numeAntrenor} nu a fost gasit.");
            }

     
            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText("clienti.txt");
            List<Client> clientiGasiti = adminClienti.SearchClienti(numeClient);
            Client client = clientiGasiti.FirstOrDefault();

            if (client == null)
            {
                throw new InvalidOperationException($"Clientul {numeClient} nu a fost gasit.");
            }

 
            AbonamentClient abonamentClientNou = new AbonamentClient(abonamentGasit, numarLuni, dataIncepere, antrenor, client)
            {
                Id = id
            };

            return abonamentClientNou;
        }
    }
}