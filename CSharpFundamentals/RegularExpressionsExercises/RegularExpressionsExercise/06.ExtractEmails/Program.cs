using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s)[a-zA-Z0-9]+[\.\-_]?[a-zA-Z0-9]+@([a-zA-Z]+)([\.\-][a-zA-Z]*)+[a-z]+";

            string input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
