using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().Replace(" ", "");

            var dictionary = new Dictionary<char, int>();

            foreach (var l in word)
            {
                if (!dictionary.ContainsKey(l))
                {
                    dictionary.Add(l, 0);
                }

                dictionary[l]++;
            }

            foreach ((char letter, int count) in dictionary)
            {
                Console.WriteLine($"{letter} -> {count}");
            }
        }
    }
}
