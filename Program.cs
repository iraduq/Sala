using System;
using System.Collections.Generic;
using System.Linq;
using SalaDeFitness.LibrarieModele;
using SalaDeFitness.NivelStocareDate;

namespace SalaDeFitness
{
    class Program
    {
        static void Main(string[] args)
        {
       
            AdministrareClienti_Memorie adminClienti = new AdministrareClienti_Memorie();
            AdministrareAntrenori_Memorie adminAntrenori = new AdministrareAntrenori_Memorie();
            AdministrareAngajati_Memorie adminAngajati = new AdministrareAngajati_Memorie();
            AdministrareAbonamenteClienti_Memorie adminAbonamente = new AdministrareAbonamenteClienti_Memorie();

            int optiune;
            do
            {
             
                Console.Clear();
                Console.WriteLine("Meniu:");
                Console.WriteLine("1. Adauga client");
                Console.WriteLine("2. Adauga antrenor");
                Console.WriteLine("3. Adauga angajat");
                Console.WriteLine("4. Adauga abonament client");
                Console.WriteLine("5. Afiseaza clienti");
                Console.WriteLine("6. Afiseaza antrenori");
                Console.WriteLine("7. Afiseaza angajati");
                Console.WriteLine("8. Afiseaza abonamente clienti");
                Console.WriteLine("9. Cauta client dupa nume");
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
                        Console.Write("Specializare: ");
                        string specializareAntrenor = Console.ReadLine();
                        Antrenor antrenor = new Antrenor(numeAntrenor, prenumeAntrenor, cnpAntrenor, emailAntrenor, telefonAntrenor, specializareAntrenor);
                        adminAntrenori.AddAntrenor(antrenor);
                        break;

                    case 3:
                     
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

                    case 4:
                   
                        Console.WriteLine("Introduceti datele pentru abonament client:");
                        Abonament tipAbonament = Abonament.TipuriAbonamente[0];
                        Console.Write("Durata abonamentului (luni): ");
                        int durataAbonament = int.Parse(Console.ReadLine());
                        Console.Write("Data inceperii (dd/MM/yyyy): ");
                        DateTime dataInceput = DateTime.Parse(Console.ReadLine());
                        Console.Write("Nume antrenor: ");
                        string numeAntrenorAbonament = Console.ReadLine();
                        Antrenor antrenorAbonament = adminAntrenori.GetAntrenori().FirstOrDefault(a => a.Nume.Equals(numeAntrenorAbonament, StringComparison.OrdinalIgnoreCase));
                        AbonamentClient abonamentClient = new AbonamentClient(tipAbonament, durataAbonament, dataInceput, antrenorAbonament);
                        adminAbonamente.AddAbonamentClient(abonamentClient);
                        break;

                    case 5:
                   
                        Console.WriteLine("\nClienti:");
                        foreach (var c in adminClienti.GetClienti())
                        {
                            Console.WriteLine(c.AfiseazaDetalii());
                        }
                        break;

                    case 6:
              
                        Console.WriteLine("\nAntrenori:");
                        foreach (var a in adminAntrenori.GetAntrenori())
                        {
                            Console.WriteLine(a.AfiseazaDetalii());
                        }
                        break;

                    case 7:
                  
                        Console.WriteLine("\nAngajati:");
                        foreach (var ang in adminAngajati.GetAngajati())
                        {
                            Console.WriteLine(ang.AfiseazaDetalii());
                        }
                        break;

                    case 8:
                    
                        Console.WriteLine("\nAbonamente Clienti:");
                        foreach (var abon in adminAbonamente.GetAbonamenteClienti())
                        {
                            Console.WriteLine(abon.AfiseazaDetalii());
                        }
                        break;

                    case 9:
                    
                        Console.WriteLine("Introduceti un nume de client pentru cautare:");
                        string cautareNume = Console.ReadLine();
                        var clientGasit = adminClienti.GetClienti().FirstOrDefault(c => c.Nume.Equals(cautareNume, StringComparison.OrdinalIgnoreCase));
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

                    case 0:
                     
                        Console.WriteLine("Iesire din program...");
                        break;

                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        break;
                }

               
                Console.WriteLine("\nApasați orice tasta pentru a continua...");
                Console.ReadKey();

            } while (optiune != 0); 
        }
    }
}
