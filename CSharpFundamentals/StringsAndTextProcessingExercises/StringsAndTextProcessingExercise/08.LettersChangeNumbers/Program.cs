using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            decimal sum = 0;

            foreach (var word in words)
            {
                char first = word[0];
                decimal number = decimal.Parse(word.Substring(1, word.Length - 2));
                char last = word[word.Length - 1];

                if (char.IsUpper(first))
                {
                    number /= alphabet.IndexOf(first);
                }
                else
                {
                    number*= alphabet.IndexOf(char.ToUpper(first));
                }

                if (char.IsUpper(last))
                {
                    number -= alphabet.IndexOf(char.ToUpper(last));
                }
                else
                {
                    number += alphabet.IndexOf(char.ToUpper(last));
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
