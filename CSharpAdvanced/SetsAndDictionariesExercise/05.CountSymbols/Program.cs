using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            foreach (var c in input)
            {
                if (!symbols.ContainsKey(c))
                {
                    symbols.Add(c, 0);
                }

                symbols[c]++;
            }

            foreach ((char symbol, int count) in symbols)
            {
                Console.WriteLine($"{symbol}: {count} time/s");
            }
        }
    }
}
