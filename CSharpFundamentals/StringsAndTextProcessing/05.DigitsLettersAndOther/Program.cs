using System;
using System.Text;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] characters = Console.ReadLine().ToCharArray();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            foreach (var c in characters)
            {
                if (char.IsDigit(c))
                {
                    digits.Append(c);
                }
                else if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
                else
                {
                    others.Append(c);
                }
            }

            Console.WriteLine(digits.ToString());
            Console.WriteLine(letters.ToString());
            Console.WriteLine(others.ToString());
        }
    }
}
