using System.Linq;

namespace SalaDeFitness.LibrarieModele
{
    public static class ValidareNumar
    {
      
        public static bool ValidareNumarTelefon(string numarTelefon)
        {
            if (string.IsNullOrWhiteSpace(numarTelefon))
            {
                return false;
            }

            numarTelefon = numarTelefon.Trim();

            if (numarTelefon.Length != 10 || !numarTelefon.All(char.IsDigit))
            {
                return false;
            }

            if (!numarTelefon.StartsWith("07"))
            {
                return false;
            }

            return true;
        }
    }
}
