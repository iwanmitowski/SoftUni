using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\=\/])(?<dest>[A-Z][A-Za-z]{2,})\1";

            var matches = Regex.Matches(Console.ReadLine(), pattern).Select(x=>x.Groups["dest"].Value).ToList();

            int points = matches.Select(x => x.Length).Sum();

            string countries = $" {string.Join(", ", matches)}";
            Console.WriteLine($"Destinations:{countries}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
