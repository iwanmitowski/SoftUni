using System;
using System.Linq;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool passLength = CheckLength(password);
            bool passSymbols = CheckSymbols(password);
            bool passDigits = CheckDigits(password);
            
            if (!passLength && !passSymbols && !passDigits)
            {
                Console.WriteLine("Password is valid");
            }

            if (passLength)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (passSymbols)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (passDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

        }

        private static bool CheckDigits(string password)
        {
            return password.Where(x => char.IsDigit(x)).Count() < 2;
        }

        private static bool CheckSymbols(string password)
        {
            return password.Any(x => !char.IsLetterOrDigit(x));
        }

        private static bool CheckLength(string password)
        {
            return password.Length < 6 || password.Length > 10;
        }
    }
}
