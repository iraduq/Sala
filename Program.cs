using System;
using System.Linq;
using SalaDeFitness.LibrarieModele;
using System.Configuration;
using SalaDeFitness.NivelStocareDate;

namespace SalaDeFitness
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeFisierClienti = ConfigurationManager.AppSettings["fisierClienti"];
            string numeFisierAntrenori = ConfigurationManager.AppSettings["fisierAntrenori"];
            string numeFisierAngajati = ConfigurationManager.AppSettings["fisierAngajati"];
            string numeFisierAbonamente = ConfigurationManager.AppSettings["fisierAbonamente"];

            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText(numeFisierClienti);
            AdministrareAntrenori_FisierText adminAntrenori = new AdministrareAntrenori_FisierText(numeFisierAntrenori);
            AdministrareAngajati_FisierText adminAngajati = new AdministrareAngajati_FisierText(numeFisierAngajati);
            AdministrareAbonamenteClienti_FisierText adminAbonamente = new AdministrareAbonamenteClienti_FisierText(numeFisierAbonamente);

            int optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("Meniu:");
                Console.WriteLine("1. Adauga client");
                Console.WriteLine("2. Afiseaza clienti");
                Console.WriteLine("3. Cauta client dupa nume");
                Console.WriteLine("4. Adauga antrenor");
                Console.WriteLine("5. Afiseaza antrenori");
                Console.WriteLine("6. Cauta antrenor dupa nume");
                Console.WriteLine("7. Adauga angajat");
                Console.WriteLine("8. Afiseaza angajati");
                Console.WriteLine("9. Cauta angajat dupa nume");
                Console.WriteLine("10. Adauga abonament");
                Console.WriteLine("11. Afiseaza abonamente");
                Console.WriteLine("12. Cauta abonament dupa detalii");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                optiune = int.Parse(Console.ReadLine());

                switch (optiune)
                {
                    case 1:
                        Console.WriteLine("Introduceti datele pentru client:");
                        Console.Write("Nume: ");
                        string numeClient = Console.ReadLine();
                        Console.Write("Prenume: ");
                        string prenumeClient = Console.ReadLine();
                        Console.Write("CNP: ");
                        string cnpClient = Console.ReadLine();
                        Console.Write("Email: ");
                        string emailClient = Console.ReadLine();
                        Console.Write("Numar telefon: ");
                        string telefonClient = Console.ReadLine();
                        Client client = new Client(numeClient, prenumeClient, cnpClient, emailClient, telefonClient);
                        adminClienti.AddClient(client);
                        break;

                    case 2:
                        Console.WriteLine("\nClienti:");
                        foreach (var c in adminClienti.GetClienti())
                        {
                            Console.WriteLine(c.AfiseazaDetalii());
                        }
                        break;

                    case 3:
                        Console.WriteLine("Introduceti un nume de client pentru cautare:");
                        string cautareNumeClient = Console.ReadLine();
                        var clientGasit = adminClienti.GetClienti().FirstOrDefault(c => c.Nume.Equals(cautareNumeClient, StringComparison.OrdinalIgnoreCase));
                        if (clientGasit != null)
                        {
                            Console.WriteLine("\nClient gasit:");
                            Console.WriteLine(clientGasit.AfiseazaDetalii());
                        }
                        else
                        {
                            Console.WriteLine("\nClientul nu a fost gasit.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Introduceti datele pentru antrenor:");
                        Console.Write("Nume: ");
                        string numeAntrenor = Console.ReadLine();
                        Console.Write("Prenume: ");
                        string prenumeAntrenor = Console.ReadLine();
                        Console.Write("CNP: ");
                        string cnpAntrenor = Console.ReadLine();
                        Console.Write("Email: ");
                        string emailAntrenor = Console.ReadLine();
                        Console.Write("Numar telefon: ");
                        string telefonAntrenor = Console.ReadLine();
                        Console.Write("Functie: ");
                        string functieAntrenor = Console.ReadLine();
                        Antrenor antrenor = new Antrenor(numeAntrenor, prenumeAntrenor, cnpAntrenor, emailAntrenor, telefonAntrenor, functieAntrenor);
                        adminAntrenori.AddAntrenor(antrenor);
                        break;

                    case 5:
                        Console.WriteLine("\nAntrenori:");
                        foreach (var a in adminAntrenori.GetAntrenori())
                        {
                            Console.WriteLine(a.AfiseazaDetalii());
                        }
                        break;

                    case 6:
                        Console.WriteLine("Introduceti un nume de antrenor pentru cautare:");
                        string cautareNumeAntrenor = Console.ReadLine();
                        var antrenorGasit = adminAntrenori.GetAntrenori().FirstOrDefault(a => a.Nume.Equals(cautareNumeAntrenor, StringComparison.OrdinalIgnoreCase));
                        if (antrenorGasit != null)
                        {
                            Console.WriteLine("\nAntrenor gasit:");
                            Console.WriteLine(antrenorGasit.AfiseazaDetalii());
                        }
                        else
                        {
                            Console.WriteLine("\nAntrenorul nu a fost gasit.");
                        }
                        break;

                    case 7:
                        Console.WriteLine("Introduceti datele pentru angajat:");
                        Console.Write("Nume: ");
                        string numeAngajat = Console.ReadLine();
                        Console.Write("Prenume: ");
                        string prenumeAngajat = Console.ReadLine();
                        Console.Write("CNP: ");
                        string cnpAngajat = Console.ReadLine();
                        Console.Write("Email: ");
                        string emailAngajat = Console.ReadLine();
                        Console.Write("Numar telefon: ");
                        string telefonAngajat = Console.ReadLine();
                        Console.Write("Functie: ");
                        string functieAngajat = Console.ReadLine();
                        Angajat angajat = new Angajat(numeAngajat, prenumeAngajat, cnpAngajat, emailAngajat, telefonAngajat, functieAngajat);
                        adminAngajati.AddAngajat(angajat);
                        break;

                    case 8:
                        Console.WriteLine("\nAngajati:");
                        foreach (var a in adminAngajati.GetAngajati())
                        {
                            Console.WriteLine(a.AfiseazaDetalii());
                        }
                        break;

                    case 9:
                        Console.WriteLine("Introduceti un nume de angajat pentru cautare:");
                        string cautareNumeAngajat = Console.ReadLine();
                        var angajatGasit = adminAngajati.GetAngajati().FirstOrDefault(a => a.Nume.Equals(cautareNumeAngajat, StringComparison.OrdinalIgnoreCase));
                        if (angajatGasit != null)
                        {
                            Console.WriteLine("\nAngajat gasit:");
                            Console.WriteLine(angajatGasit.AfiseazaDetalii());
                        }
                        else
                        {
                            Console.WriteLine("\nAngajatul nu a fost gasit.");
                        }
                        break;

                    case 10:
                        Console.WriteLine("Introduceti datele pentru abonament:");
                        Console.Write("Tip abonament: ");
                        string tipAbonamentNou = Console.ReadLine();
                        Console.Write("Numar luni: ");
                        int numarLuniAbonament = int.Parse(Console.ReadLine());
                        DateTime dataIncepereAbonament = DateTime.Now;
                        DateTime dataExpirareAbonament = dataIncepereAbonament.AddMonths(numarLuniAbonament);

                        Console.WriteLine($"Data inceperii abonamentului: {dataIncepereAbonament.ToString("yyyy-MM-dd")}");
                        Console.WriteLine($"Data expirarii abonamentului: {dataExpirareAbonament.ToString("yyyy-MM-dd")}");

                        Console.WriteLine("\nSelectează un antrenor existent din lista:");
                        var listaAntrenori = adminAntrenori.GetAntrenori();
                        for (int i = 0; i < listaAntrenori.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {listaAntrenori.ElementAt(i).AfiseazaDetalii()}");
                        }

                        Console.Write("Alege un numar de antrenor: ");
                        int indexAntrenorSelectat = int.Parse(Console.ReadLine()) - 1; 
                        Antrenor antrenorAbonamentSelectat = null;
                        if (indexAntrenorSelectat >= 0 && indexAntrenorSelectat < listaAntrenori.Count())
                        {
                            antrenorAbonamentSelectat = listaAntrenori.ElementAt(indexAntrenorSelectat);
                        }
                        else
                        {
                            Console.WriteLine("Numar invalid de antrenor.");
                            break;
                        }

                    
                        Console.WriteLine("\nSelectează un client existent din lista:");
                        var listaClienti = adminClienti.GetClienti();
                        for (int i = 0; i < listaClienti.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {listaClienti.ElementAt(i).AfiseazaDetalii()}");
                        }

                        Console.Write("Alege un numar de client: ");
                        int indexClientSelectat = int.Parse(Console.ReadLine()) - 1; 
                        Client clientAbonamentSelectat = null;
                        if (indexClientSelectat >= 0 && indexClientSelectat < listaClienti.Count())
                        {
                            clientAbonamentSelectat = listaClienti.ElementAt(indexClientSelectat);
                        }
                        else
                        {
                            Console.WriteLine("Numar invalid de client.");
                            break;
                        }

                     
                        Abonament abonamentNou = new Abonament(tipAbonamentNou, 50);
                        AbonamentClient abonamentClientNou = new AbonamentClient(abonamentNou, numarLuniAbonament, dataIncepereAbonament, antrenorAbonamentSelectat, clientAbonamentSelectat);



                        clientAbonamentSelectat.AbonamentClient = abonamentClientNou;
                        
                        clientAbonamentSelectat.Status = "Activ"; 

                 
                        adminAbonamente.AddAbonamentClient(abonamentClientNou);

                        Console.WriteLine("Abonamentul a fost atribuit cu succes clientului!");
                        break;





                    case 11:
                        var abonamente = adminAbonamente.GetAbonamenteClienti();
                        Console.WriteLine($"Număr de abonamente: {abonamente.Count}");

                        Console.WriteLine("Abonamentele existente:");
                        foreach (var abonament in abonamente)
                        {
                            Console.WriteLine($"Tip: {abonament.Abonament.Tip}, Nr. Luni: {abonament.NrLuni}, " +
                                              $"Început: {abonament.DataInceperii.ToShortDateString()}, " +
                                              $"Expirare: {abonament.DataExpirarii.ToShortDateString()}, " +
                                              $"Antrenor: {abonament.Antrenor.Nume}, Client: {abonament.Client.Nume}");
                        }
                        break;

                    case 12:
                        Console.WriteLine("Introduceti detalii pentru cautare abonament:");
                        string detaliiAbonament = Console.ReadLine();
                        var abonamentGasit = adminAbonamente.SearchAbonamenteClienti(detaliiAbonament);
                        if (abonamentGasit.Count > 0)
                        {
                            Console.WriteLine("\nAbonamente gasite:");
                            foreach (var ab in abonamentGasit)
                            {
                                Console.WriteLine(ab.AfiseazaDetalii());
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNu au fost gasite abonamente.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Iesire din program...");
                        break;

                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        break;
                }

                Console.WriteLine("\nApasati orice tasta pentru a continua...");
                Console.ReadKey();

            } while (optiune != 0);
        }
    }
}
