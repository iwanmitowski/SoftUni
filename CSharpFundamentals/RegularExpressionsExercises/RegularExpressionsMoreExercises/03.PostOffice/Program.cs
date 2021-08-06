using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string lettersPattern = @"([#$%*&])(?<letters>[A-Z]+)\1";

            string[] input = Console.ReadLine().Split("|");

            var lettersLength = new Dictionary<char, int>();

            var letterMatches = Regex.Matches(input[0], lettersPattern)[0].Groups["letters"].Value.ToCharArray();

            foreach (var l in letterMatches)
            {
                string codeLengthPattern = $@"(?<code>{(int)l}):(?<length>[0-9][0-9])";
                var length = int.Parse(Regex.Match(input[1], codeLengthPattern).Groups["length"].Value);

                lettersLength.Add(l, length);
            }

            foreach ((char letter, int length) in lettersLength)
            {
                string wordPattern = $@"(?<=\s|^)[{letter}][\S]{{{length}}}\b";

                var word = Regex.Matches(input[2], wordPattern).First().Value;
                Console.WriteLine(word);
            }
        }
    }
}

