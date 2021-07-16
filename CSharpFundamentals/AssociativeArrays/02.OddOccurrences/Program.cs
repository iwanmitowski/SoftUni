using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();

            string[] words = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();

            foreach (var word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 0);
                }

                dictionary[word]++;
            }

            var x = dictionary.Where(x => x.Value % 2 != 0)
                .ToDictionary(k => k.Key, v => v.Value)
                .Keys;
            
            Console.WriteLine(string.Join(" ", x));
        }
    }
}
