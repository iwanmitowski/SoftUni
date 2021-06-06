using System;
using System.Text;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            Console.WriteLine(FindBetween(first, second));
        }

        private static string FindBetween(char first, char second)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = Math.Min(first,second)+1; i < Math.Max(first,second); i++)
            {
                sb.Append((char)i + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
