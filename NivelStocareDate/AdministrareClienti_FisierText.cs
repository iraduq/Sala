using System;
using System.Collections.Generic;
using System.IO;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareClienti_FisierText
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private readonly string fisierClienti;

    
        private const int INDEX_NUME = 0;
        private const int INDEX_PRENUME = 1;
        private const int INDEX_CNP = 2;
        private const int INDEX_EMAIL = 3;
        private const int INDEX_NUMAR_TELEFON = 4;
        private const int INDEX_ABONAMENT_INFO = 5;

        public AdministrareClienti_FisierText(string numeFisier)
        {
            this.fisierClienti = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddClient(Client client)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(fisierClienti, true))
            {
                streamWriterFisierText.WriteLine(ConversieLaSir_PentruFisier(client));
            }
        }

        public List<Client> GetClienti()
        {
            List<Client> clienti = new List<Client>();

            using (StreamReader streamReader = new StreamReader(fisierClienti))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    clienti.Add(ConversieClient_DinSirFisier(linieFisier));
                }
            }

            return clienti;
        }

        public bool DeleteClient(string cnp)
        {
            List<Client> clienti = GetClienti();
            bool gasit = false;

            clienti.RemoveAll(c =>
            {
                if (c.CNP == cnp)
                {
                    gasit = true;
                    return true;
                }
                return false;
            });

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierClienti, false))
                {
                    foreach (var client in clienti)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(client));
                    }
                }
            }

            return gasit;
        }

        public bool UpdateClient(Client clientActualizat)
        {
            List<Client> clienti = GetClienti();
            bool gasit = false;

            for (int i = 0; i < clienti.Count; i++)
            {
                if (clienti[i].CNP == clientActualizat.CNP)
                {
                    clienti[i] = clientActualizat;
                    gasit = true;
                    break;
                }
            }

            if (gasit)
            {
                using (StreamWriter streamWriter = new StreamWriter(fisierClienti, false))
                {
                    foreach (var client in clienti)
                    {
                        streamWriter.WriteLine(ConversieLaSir_PentruFisier(client));
                    }
                }
            }

            return gasit;
        }

        public List<Client> SearchClienti(string searchText)
        {
            List<Client> totiClientii = GetClienti();
            List<Client> clientiGasiti = new List<Client>();

            if (string.IsNullOrEmpty(searchText))
            {
                return totiClientii;
            }

            foreach (var client in totiClientii)
            {
                if ((client.Nume != null && client.Nume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.Prenume != null && client.Prenume.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.CNP != null && client.CNP.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.Email != null && client.Email.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.NumarTelefon != null && client.NumarTelefon.IndexOf(searchText) >= 0))
                {
                    clientiGasiti.Add(client);
                }
            }

            return clientiGasiti;
        }

        private string ConversieLaSir_PentruFisier(Client client)
        {
            string abonamentInfo = client.AbonamentClient != null ? client.AbonamentClient.ToString() : "null";

            return $"{client.Nume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{client.Prenume}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{client.CNP}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{client.Email}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{client.NumarTelefon}{SEPARATOR_PRINCIPAL_FISIER}" +
                   $"{abonamentInfo}";
        }


        private Client ConversieClient_DinSirFisier(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            string Nume = dateFisier[INDEX_NUME];
            string Prenume = dateFisier[INDEX_PRENUME];
            string CNP = dateFisier[INDEX_CNP];
            string Email = dateFisier[INDEX_EMAIL];
            string NumarTelefon = dateFisier[INDEX_NUMAR_TELEFON];

            Client client = new Client(Nume, Prenume, CNP, Email, NumarTelefon);

            if (dateFisier.Length > INDEX_ABONAMENT_INFO && dateFisier[INDEX_ABONAMENT_INFO] != "null")
            {
                //  informatii despre abonament
            }

            return client;
        }
    }
}
