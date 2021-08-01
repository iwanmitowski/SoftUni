using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternName = @"[A-Za-z]";
            string patternDigits = @"[0-9]";

            var dictionary = new Dictionary<string, int>();

            string[] names = Console.ReadLine().Split(", ");

            foreach (var name in names)
            {
                dictionary.Add(name, 0);
            }

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                var name = string.Join("", Regex.Matches(input, patternName).ToList());

                if (dictionary.ContainsKey(name))
                {
                    var sum = Regex.Matches(input, patternDigits).Select(x => int.Parse(x.ToString())).ToList();
                    int sumingz = sum.Sum();
                    dictionary[name] += sumingz;
                }

                input = Console.ReadLine();
            }

            int counter = 1;
            foreach (var item in dictionary.OrderByDescending(x => x.Value))
            {
                string place = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";

                Console.WriteLine($"{counter++}{place} place: {item.Key}");

                if (counter == 4)
                {
                    break;
                }
            }
        }
    }
}
