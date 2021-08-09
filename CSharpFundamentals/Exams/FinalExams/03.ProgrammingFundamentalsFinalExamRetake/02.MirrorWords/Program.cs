using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\#\@])(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";

            var matches = Regex.Matches(Console.ReadLine(), pattern);

            if (matches.Count==0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            List<Match> pairs = matches.Where(x => string.Join("", x.Groups["wordOne"].Value.Reverse()) == x.Groups["wordTwo"].Value).ToList();


            List<string> result = new List<string>();
            if (pairs.Count==0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                foreach (var pair in pairs)
                {
                    result.Add($"{pair.Groups["wordOne"].Value} <=> {pair.Groups["wordTwo"].Value}");
                }

                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ",result));
            }
        }
    }
}
