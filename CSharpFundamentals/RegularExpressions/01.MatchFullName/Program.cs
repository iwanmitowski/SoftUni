using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            Regex regex = new Regex(pattern);

            string names = Console.ReadLine();

            var matches = regex.Matches(names);

            foreach (Match match in matches)
            {
                Console.Write($"{match} ");
            }
        }
    }
}
