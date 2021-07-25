using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSum = 0;
            List<string> words = Console.ReadLine().Split().ToList();
            int index = -1;
            int minLength = Math.Min(words[0].Length, words[1].Length);

            for (int i = 0; i < minLength; i++)
            {
                index = i;
                totalSum += words[0][i] * words[1][i];
            }

            if (index != -1)
            {
                string wordToRemove = words.First(x => x.Length == minLength);
                words.Remove(wordToRemove);

                for (int i = index + 1; i < words[0].Length; i++)
                {
                    totalSum += words[0][i];
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
