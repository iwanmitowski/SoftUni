using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(([\D]+)([\d]+))";

            string input = Console.ReadLine().ToUpper();

            var matches = Regex.Matches(input, pattern);

            StringBuilder sb = new StringBuilder();
            
            foreach (Match match in matches)
            {
                string text = match.Groups[2].Value;
                int count = int.Parse(match.Groups[3].Value);

                sb.Append(string.Concat(Enumerable.Repeat(text, count)));
            }

            string result = sb.ToString();
            int uniqueSymbols = result.Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbols}");
            Console.WriteLine(result);
        }
    }
}
