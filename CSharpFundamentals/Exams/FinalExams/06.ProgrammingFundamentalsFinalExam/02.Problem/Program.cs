using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(.+)>(?<numbers>\d{3})\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<symbols>[^\<\>]{3})<\1";
            for (int i = 0; i < n; i++)
            {
                var match = Regex.Match(Console.ReadLine(),pattern);

                if (match.Success)
                {
                    Console.WriteLine($"Password: {match.Groups["numbers"].Value}{match.Groups["lower"].Value}{match.Groups["upper"].Value}{match.Groups["symbols"].Value}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
