using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> morseAlphabet = new List<string>() { "·−", "−···", "-·−·", "−··", "·", "··−·", "−−·", "····", "..", "·−−−", "−·−", "·−··", "−−", "−·", "−−−", "·−−·", "−−·−", "·−·", "···", "−", "··−", "···−", "·−−", "−··−", "−·−−", "−−··" };
            string fixingMorse = string.Join(" ", morseAlphabet);
            fixingMorse = fixingMorse.Replace('·', '.');
            fixingMorse = fixingMorse.Replace('−', '-');

            List<string> fixedMorse = fixingMorse.Split().ToList();

            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string[] words = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var letter in words)
            {
                int index = fixedMorse.IndexOf(letter) + 1;

                sb.Append(alphabet[index]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
