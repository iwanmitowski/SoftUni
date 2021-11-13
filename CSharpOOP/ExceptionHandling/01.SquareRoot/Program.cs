using System;

namespace _01.SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(int.Parse("9999999999223372036854775807"));
            string input = Console.ReadLine();

            try
            {
                ValidateNumber(input);
                Console.WriteLine(Math.Sqrt(int.Parse(input)));
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine(aore.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
             
        }

        private static void ValidateNumber(string input)
        {
            int number;

            if (!int.TryParse(input, out number))
            {
                throw new FormatException("Invalid number");
            }

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid number");
            }
        }
    }
}
