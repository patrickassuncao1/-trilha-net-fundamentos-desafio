using System.Text.RegularExpressions;

namespace Challenge.Models
{
    public class ValidateLicensePlate
    {
        public static bool Validate(string vehiclePlate)
        {
            if (string.IsNullOrWhiteSpace(vehiclePlate)) { return false; }

            if (vehiclePlate.Length < 5 || vehiclePlate.Length > 8) { return false; }

            vehiclePlate = vehiclePlate.Replace("-", "").Trim();

            if (char.IsLetter(vehiclePlate, 4))
            {
                /*
                 *  Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                 */
                Regex mercosulPattern = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return mercosulPattern.IsMatch(vehiclePlate);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                Regex normalPattern = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return normalPattern.IsMatch(vehiclePlate);
            }

        }
    }
}