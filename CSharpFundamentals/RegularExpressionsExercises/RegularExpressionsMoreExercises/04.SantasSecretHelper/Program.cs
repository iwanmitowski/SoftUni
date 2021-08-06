using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<type>[G|N])!";

            string input = Console.ReadLine();

            while (input!="end")
            {
                string word = string.Join("", input.Select(x => (char)(x - key)).ToArray());
                var match = Regex.Match(word, pattern);
                if (match.Groups["type"].Value == "G")
                {
                    Console.WriteLine(match.Groups["name"].Value);
                }

                input = Console.ReadLine();
            }
        }
    }
}
