using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\:|\*){2}(?<emoji>[A-Z][a-z]{2,})\1{2}";

            var numbers = Regex.Matches(input, @"\d").Select(x => int.Parse(x.Value)).ToList();

            BigInteger coolthreshold = 1;

            foreach (var item in numbers)
            {
                coolthreshold *= item;
            }

            var matches = Regex.Matches(input, pattern); ;

            Console.WriteLine($"Cool threshold: {coolthreshold}");
            Console.WriteLine($"{matches.Count()} emojis found in the text. The cool ones are:");
            foreach (Match match in matches)
            {
                int sum = match.Groups["emoji"].Value.Select(x => (int)x).Sum();

                if (sum > coolthreshold)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
