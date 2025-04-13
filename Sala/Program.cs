using System;
using System.Linq;
using SalaDeFitness.LibrarieModele;
using System.Configuration;
using SalaDeFitness.NivelStocareDate;
using System.IO;

namespace SalaDeFitness
{
    class Program
    {
        enum MenuOptions
        {
            AddClient = 1 << 0,
            ShowClients = 1 << 1,
            SearchClient = 1 << 2,
            AddTrainer = 1 << 3,
            ShowTrainers = 1 << 4,
            SearchTrainer = 1 << 5,
            AddEmployee = 1 << 6,
            ShowEmployees = 1 << 7,
            SearchEmployee = 1 << 8,
            AddSubscription = 1 << 9,
            ShowSubscriptions = 1 << 10,
            SearchSubscription = 1 << 11,
            Exit = 1 << 12
        }

        static void Main(string[] args)
        {

            string locatieFisierSolutie = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string numeFisierClienti = "clienti.txt";
            string numeFisierAntrenori = "antrenori.txt";
            string numeFisierAngajati = "angajati.txt";
            string numeFisierAbonamente = "abonamente.txt";
            
            string caleCompletaFisierClienti = Path.Combine(locatieFisierSolutie, numeFisierClienti);
            string caleCompletaFisierAntrenori = Path.Combine(locatieFisierSolutie, numeFisierAntrenori);
            string caleCompletaFisierAngajati = Path.Combine(locatieFisierSolutie, numeFisierAngajati);
            string caleCompletaFisierAbonamente = Path.Combine(locatieFisierSolutie, numeFisierAbonamente);


            AdministrareClienti_FisierText adminClienti = new AdministrareClienti_FisierText(caleCompletaFisierClienti);
            AdministrareAntrenori_FisierText adminAntrenori = new AdministrareAntrenori_FisierText(caleCompletaFisierAntrenori);
            AdministrareAngajati_FisierText adminAngajati = new AdministrareAngajati_FisierText(caleCompletaFisierAngajati);
            AdministrareAbonamenteClienti_FisierText adminAbonamente = new AdministrareAbonamenteClienti_FisierText(caleCompletaFisierAbonamente);

            MenuOptions menuFlags = MenuOptions.AddClient | MenuOptions.ShowClients | MenuOptions.SearchClient | MenuOptions.AddTrainer |
                                     MenuOptions.ShowTrainers | MenuOptions.SearchTrainer | MenuOptions.AddEmployee | MenuOptions.ShowEmployees |
                                     MenuOptions.SearchEmployee | MenuOptions.AddSubscription | MenuOptions.ShowSubscriptions | MenuOptions.SearchSubscription |
                                     MenuOptions.Exit;

            int optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("Meniu:");
                if (menuFlags.HasFlag(MenuOptions.AddClient)) Console.WriteLine("1. Adauga client");
                if (menuFlags.HasFlag(MenuOptions.ShowClients)) Console.WriteLine("2. Afiseaza clienti");
                if (menuFlags.HasFlag(MenuOptions.SearchClient)) Console.WriteLine("3. Cauta client dupa nume");
                if (menuFlags.HasFlag(MenuOptions.AddTrainer)) Console.WriteLine("4. Adauga antrenor");
                if (menuFlags.HasFlag(MenuOptions.ShowTrainers)) Console.WriteLine("5. Afiseaza antrenori");
                if (menuFlags.HasFlag(MenuOptions.SearchTrainer)) Console.WriteLine("6. Cauta antrenor dupa nume");
                if (menuFlags.HasFlag(MenuOptions.AddEmployee)) Console.WriteLine("7. Adauga angajat");
                if (menuFlags.HasFlag(MenuOptions.ShowEmployees)) Console.WriteLine("8. Afiseaza angajati");
                if (menuFlags.HasFlag(MenuOptions.SearchEmployee)) Console.WriteLine("9. Cauta angajat dupa nume");
                if (menuFlags.HasFlag(MenuOptions.AddSubscription)) Console.WriteLine("10. Adauga abonament");
                if (menuFlags.HasFlag(MenuOptions.ShowSubscriptions)) Console.WriteLine("11. Afiseaza abonamente");
                if (menuFlags.HasFlag(MenuOptions.SearchSubscription)) Console.WriteLine("12. Cauta abonament dupa detalii");
                if (menuFlags.HasFlag(MenuOptions.Exit)) Console.WriteLine("0. Iesire");
                Console.Write("Alege o optiune: ");

                optiune = int.Parse(Console.ReadLine());


                if (menuFlags.HasFlag((MenuOptions)(1 << (optiune - 1))))
                {
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
                            Console.WriteLine(angajat.AfiseazaDetalii());
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
                            Console.Write("Tip abonament: ");
                            string tipAbonamentNou = Console.ReadLine();

                            Abonament abonamentSelectat = Abonament.TipuriAbonamente.FirstOrDefault(a => a.Tip.Equals(tipAbonamentNou, StringComparison.OrdinalIgnoreCase));

                            if (abonamentSelectat == null)
                            {
                                Console.WriteLine("Tipul de abonament nu este valid.");
                                break;
                            }

                            Console.Write("Numar luni: ");
                            int numarLuniAbonament = int.Parse(Console.ReadLine());
                            DateTime dataIncepereAbonament = DateTime.Now;
                            DateTime dataExpirareAbonament = dataIncepereAbonament.AddMonths(numarLuniAbonament);

                            Console.WriteLine($"Data inceperii abonamentului: {dataIncepereAbonament.ToString("yyyy-MM-dd")}");
                            Console.WriteLine($"Data expirarii abonamentului: {dataExpirareAbonament.ToString("yyyy-MM-dd")}");

                            Console.WriteLine("\nSelecteaza un antrenor existent din lista:");
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


                            Console.WriteLine("\nSelecteaza un client existent din lista:");
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

                            AbonamentClient abonamentClientNou = new AbonamentClient(abonamentSelectat, numarLuniAbonament, dataIncepereAbonament, antrenorAbonamentSelectat, clientAbonamentSelectat)
                            {
                                Id = Guid.NewGuid()
                            };

                            clientAbonamentSelectat.AbonamentClient = abonamentClientNou;
                            clientAbonamentSelectat.Status = "Activ";
                            adminAbonamente.AddAbonamentClient(abonamentClientNou);
                            Console.WriteLine("Abonamentul a fost atribuit cu succes clientului!");
                            break;

                        case 11:
                            var abonamente = adminAbonamente.GetAbonamenteClienti();
                            Console.WriteLine($"Numar de abonamente: {abonamente.Count}");

                            Console.WriteLine("Abonamentele existente:");
                            foreach (var abonament in abonamente)
                            {
                                Console.WriteLine(abonament.AfiseazaDetalii());
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
                }
                else
                {
                    Console.WriteLine("Optiune invalida. Incercati din nou.");
                }
                Console.WriteLine("\nApasati orice tasta pentru a continua...");
                Console.ReadKey();

            } while (optiune != 0);
        }
    }
}
