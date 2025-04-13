using System.Windows.Forms;
using System;
using System.Drawing;
using SalaDeFitness.LibrarieModele;
using SalaDeFitness.NivelStocareDate;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Interfata.Validari
{
    public static class ValidationMessages
    {
        // Nume si Prenume
        public const string RequiredField = "Acest camp este obligatoriu!";
        public const string NameTooLong = "Numele trebuie sa fie mai scurt de 16 caractere!";
        public const string NameTooShort = "Numele trebuie sa aiba cel putin 3 caractere!";
        public const string NameOnlyLetters = "Numele trebuie sa contina doar litere!";
        public const string NameFirstLetterCapital = "Numele trebuie sa inceapa cu litera mare!";
        public const string NameNoLeadingTrailingSpaces = "Numele nu poate contine spatii la inceput sau sfarsit!";
        public const string NameInvalidCharacters = "Numele nu poate contine caractere invalide!";
        public const string NameContainsSpecialChars = "Numele nu poate contine caractere speciale (ex: @, #, $, etc.)!";
        public const string NameContainsDigits = "Numele nu poate contine cifre!";
        public const string NameCannotBeDefault = "Numele sau Prenumele nu poate fi 'Nume' sau 'Prenume'!";

        // CNP
        public const string InvalidCNP = "CNP-ul trebuie sa aiba exact 13 cifre!";
        public const string CNPOnlyDigits = "CNP-ul trebuie sa contina doar cifre!";
        public const string InvalidCNPLength = "CNP-ul trebuie sa aiba exact 13 cifre!";
        public const string InvalidCNPLuna = "CNP-ul contine o luna invalida!";
        public const string InvalidCNPZi = "CNP-ul contine o zi invalida!";
        public const string InvalidCNPFirstDigit = "CNP-ul trebuie sa inceapa cu 1, 2, 5 sau 6!";
        public const string CNPInvalidDate = "CNP-ul contine o data invalida!";

        // Email
        public const string InvalidEmail = "Email invalid!";
        public const string EmailMissingAt = "Email-ul trebuie sa contina '@'!";
        public const string EmailMissingDomain = "Email-ul trebuie sa contina un domeniu valid!";
        public const string EmailContainsSpaces = "Email-ul nu poate contine spatii!";
        public const string EmailInvalidCharacters = "Email-ul contine caractere invalide!";
        public const string EmailTooLong = "Email-ul nu poate depasi 255 de caractere!";
        public const string EmailInvalidTLD = "Email-ul trebuie sa aiba o extensie de domeniu valida!";

        // Telefon
        public const string InvalidPhone = "Telefonul trebuie sa aiba 10 cifre!";
        public const string PhoneOnlyDigits = "Telefonul trebuie sa contina doar cifre!";
        public const string PhoneInvalidPrefix = "Numarul trebuie sa inceapa cu '07'!";
        public const string PhoneNoSpaces = "Numarul nu poate contine spatii!";
        public const string PhoneInvalidCountryCode = "Numarul de telefon trebuie sa inceapa cu un cod de tara valid!";

        // Functie
        public const string FunctionRequiredField = "Acest camp este obligatoriu!";
        public const string FunctionTooLong = "Functia trebuie sa fie mai scurta de 16 caractere!";
        public const string FunctionTooShort = "Functia trebuie sa aiba cel putin 3 caractere!";
        public const string FunctionOnlyLetters = "Functia trebuie sa contina doar litere si spatii!";
        public const string FunctionFirstLetterCapital = "Functia trebuie sa inceapa cu litera mare!";
        public const string FunctionNoLeadingTrailingSpaces = "Functia nu poate contine spatii la inceput sau sfarsit!";
        public const string FunctionInvalidCharacters = "Functia nu poate contine caractere invalide!";
        public const string FunctionContainsSpecialChars = "Functia nu poate contine caractere speciale (ex: @, #, $, etc.)!";
        public const string FunctionContainsDigits = "Functia nu poate contine cifre!";
        public const string FunctionCannotBeDefault = "Functia nu poate fi 'functie'!";

        // Abonament
        public static string TipAbonamentRequired = "Tipul de abonament este obligatoriu.";
        public static string InvalidNumberOfMonths = "Numarul de luni trebuie sa fie un numar pozitiv.";
        public static string BigNumberOfMonths = "Abonamentul poate fi facut pe maxim 12 luni.";
        public static string AntrenorRequired = "Antrenorul este obligatoriu.";
        public static string ClientRequired = "Clientul este obligatoriu.";
    }

    public static class ValidationConstants
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 16;

        public const int FunctionMinLength = 3;
        public const int FunctionMaxLength = 16;

        public const int MaxEmailLength = 255;
        public const int CnpLength = 13;
        public const int PhoneLength = 10;
        public const int MaxLuni = 12;

        public const string DefaultName1 = "nume";
        public const string DefaultName2 = "prenume";
        public const string DefaultFunction = "functie";

        public const string PhonePrefix = "07";

        public static readonly char[] ValidCnpStartDigits = { '1', '2', '5', '6' };
        public static readonly int[] MonthsWith30Days = { 4, 6, 9, 11 };
    }

    public static class Validator
    {
        public static string ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return ValidationMessages.RequiredField;

            if (name.Length < ValidationConstants.NameMinLength)
                return ValidationMessages.NameTooShort;

            if (name.Length > ValidationConstants.NameMaxLength)
                return ValidationMessages.NameTooLong;

            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                return ValidationMessages.NameOnlyLetters;

            if (char.IsLower(name[0]))
                return ValidationMessages.NameFirstLetterCapital;

            if (name.StartsWith(" ") || name.EndsWith(" "))
                return ValidationMessages.NameNoLeadingTrailingSpaces;

            if (name.Contains(" "))
                return ValidationMessages.NameContainsSpecialChars;

            if (Regex.IsMatch(name, @"\d"))
                return ValidationMessages.NameContainsDigits;

            var lowerTrimmedName = name.Trim().ToLower();
            if (lowerTrimmedName == ValidationConstants.DefaultName1 || lowerTrimmedName == ValidationConstants.DefaultName2)
                return ValidationMessages.NameCannotBeDefault;

            return null;
        }

        public static string ValidateCNP(string cnp)
        {
            if (string.IsNullOrEmpty(cnp))
                return ValidationMessages.RequiredField;

            if (cnp.Length != ValidationConstants.CnpLength)
                return ValidationMessages.InvalidCNPLength;

            if (!Regex.IsMatch(cnp, @"^\d{13}$"))
                return ValidationMessages.CNPOnlyDigits;

            int month = int.Parse(cnp.Substring(3, 2));
            if (month < 1 || month > 12)
                return ValidationMessages.InvalidCNPLuna;

            int day = int.Parse(cnp.Substring(5, 2));
            if (day < 1 || day > 31)
                return ValidationMessages.InvalidCNPZi;

            if (ValidationConstants.MonthsWith30Days.Contains(month) && day > 30)
                return ValidationMessages.CNPInvalidDate;

            if (month == 2)
            {
                int year = int.Parse(cnp.Substring(1, 2)) + 1900;
                bool isLeapYear = DateTime.IsLeapYear(year);
                if ((isLeapYear && day > 29) || (!isLeapYear && day > 28))
                    return ValidationMessages.CNPInvalidDate;
            }

            if (!ValidationConstants.ValidCnpStartDigits.Contains(cnp[0]))
                return ValidationMessages.InvalidCNPFirstDigit;

            return null;
        }

        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return ValidationMessages.RequiredField;

            if (email.Length > ValidationConstants.MaxEmailLength)
                return ValidationMessages.EmailTooLong;

            if (!email.Contains("@"))
                return ValidationMessages.EmailMissingAt;

            int domainIndex = email.IndexOf('@') + 1;
            if (domainIndex >= email.Length || !email.Substring(domainIndex).Contains("."))
                return ValidationMessages.EmailMissingDomain;

            if (email.Contains(" "))
                return ValidationMessages.EmailContainsSpaces;

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9@._-]+$"))
                return ValidationMessages.EmailInvalidCharacters;

            if (!Regex.IsMatch(email, @"\.[a-zA-Z]{2,}$"))
                return ValidationMessages.EmailInvalidTLD;

            return null;
        }

        public static string ValidatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return ValidationMessages.RequiredField;

            if (phone.Length != ValidationConstants.PhoneLength)
                return ValidationMessages.InvalidPhone;

            if (!Regex.IsMatch(phone, @"^\d{10}$"))
                return ValidationMessages.PhoneOnlyDigits;

            if (!phone.StartsWith(ValidationConstants.PhonePrefix))
                return ValidationMessages.PhoneInvalidPrefix;

            if (phone.Contains(" "))
                return ValidationMessages.PhoneNoSpaces;

            return null;
        }

        public static string ValidateFunctie(string functie)
        {
            if (string.IsNullOrEmpty(functie))
                return ValidationMessages.FunctionRequiredField;

            if (functie.Length < ValidationConstants.FunctionMinLength)
                return ValidationMessages.FunctionTooShort;

            if (functie.Length > ValidationConstants.FunctionMaxLength)
                return ValidationMessages.FunctionTooLong;

            if (!Regex.IsMatch(functie, @"^[a-zA-Z\s]+$"))
                return ValidationMessages.FunctionOnlyLetters;

            if (char.IsLower(functie[0]))
                return ValidationMessages.FunctionFirstLetterCapital;

            if (functie.StartsWith(" ") || functie.EndsWith(" "))
                return ValidationMessages.FunctionNoLeadingTrailingSpaces;

            if (functie.Contains("  "))
                return ValidationMessages.FunctionContainsSpecialChars;

            if (Regex.IsMatch(functie, @"\d"))
                return ValidationMessages.FunctionContainsDigits;

            if (functie.Trim().ToLower() == ValidationConstants.DefaultFunction)
                return ValidationMessages.FunctionCannotBeDefault;

            return null;
        }

        public static string ValidateTipAbonament(string tipAbonament)
        {
            if (string.IsNullOrEmpty(tipAbonament))
                return ValidationMessages.TipAbonamentRequired;

            return null;
        }

        public static string ValidateNumarLuni(string numarLuniText)
        {
            if (!int.TryParse(numarLuniText, out int numarLuni) || numarLuni <= 0)
                return ValidationMessages.InvalidNumberOfMonths;

            if (numarLuni > ValidationConstants.MaxLuni)
                return ValidationMessages.BigNumberOfMonths;

            return null;
        }

        public static string ValidateAntrenor(Antrenor antrenor)
        {
            if (antrenor == null)
                return ValidationMessages.AntrenorRequired;

            return null;
        }

        public static string ValidateClient(Client client)
        {
            if (client == null)
                return ValidationMessages.ClientRequired;

            return null;
        }
    }
}
