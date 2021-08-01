using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternStar = @"[SsTtAaRr]";
            string patternDecrypted = @"@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*:(?<population>\d+)[^\@\-\!\:\>]*!(?<type>[A|D])![^\@\-\!\:\>]*\-\>(?<soldier>\d+)";

            int n = int.Parse(Console.ReadLine());

            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int stars = Regex.Matches(input, patternStar).Count;

                StringBuilder planet = new StringBuilder();

                foreach (var l in input)
                {
                    planet.Append((char)(l - stars));
                }

                var match = Regex.Match(planet.ToString(), patternDecrypted);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;

                    if (type=="A")
                    {
                        attacked.Add(name);
                    }
                    else
                    {
                        destroyed.Add(name);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var p in attacked.OrderBy(x => x))
            {
                Console.WriteLine($"-> {p}");
            }

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var p in destroyed.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {p}");
            }
        }
    }
}
