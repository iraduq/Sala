namespace SalaDeFitness.LibrarieModele
{
    public class Validare
    {
        public bool ValidareEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] partileEmailului = email.Split('@');
            if (partileEmailului.Length != 2)
            {
                return false;
            }

            string parteaLocala = partileEmailului[0];
            string parteaDomeniului = partileEmailului[1];

            if (string.IsNullOrWhiteSpace(parteaLocala) || string.IsNullOrWhiteSpace(parteaDomeniului))
            {
                return false;
            }

            foreach (char caracter in parteaLocala)
            {
                if (!char.IsLetterOrDigit(caracter) && caracter != '.' && caracter != '_' && caracter != '-')
                {
                    return false;
                }
            }

            if (parteaDomeniului.Length < 2 || !parteaDomeniului.Contains(".") || parteaDomeniului.Split('.').Length != 2 || parteaDomeniului.EndsWith(".") || parteaDomeniului.StartsWith("."))
            {
                return false;
            }

            return true;
        }
    }
}
