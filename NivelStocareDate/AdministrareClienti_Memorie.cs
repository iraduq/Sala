using System.Collections.Generic;
using SalaDeFitness.LibrarieModele;

namespace SalaDeFitness.NivelStocareDate
{
    public class AdministrareClienti_Memorie
    {
        private List<Client> clienti;

        public AdministrareClienti_Memorie()
        {
            clienti = new List<Client>();
        }

        public void AddClient(Client client)
        {
            clienti.Add(client);
        }

        public List<Client> GetClienti()
        {
            return clienti;
        }
    }
}