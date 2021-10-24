using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var vowels = new Queue<string>(Console.ReadLine().Split());
            var consonants = new Stack<string>(Console.ReadLine().Split());

            var wordsAndLetters = new Dictionary<string, HashSet<string>>();

            wordsAndLetters["pear"] = new HashSet<string>();
            wordsAndLetters["flour"] = new HashSet<string>();
            wordsAndLetters["pork"] = new HashSet<string>();
            wordsAndLetters["olive"] = new HashSet<string>();

            while (consonants.Any())
            {
                string currentVowel = vowels.Dequeue();
                vowels.Enqueue(currentVowel);
                string currentConsonant = consonants.Pop();

                foreach ((string word, HashSet<string> letters) in wordsAndLetters)
                {
                    if (word.Contains(currentVowel))
                    {
                        wordsAndLetters[word].Add(currentVowel);
                    }

                    if (word.Contains(currentConsonant))
                    {
                        wordsAndLetters[word].Add(currentConsonant);
                    }
                }
            }

            List<string> wordsFound = wordsAndLetters
                .Where(x => x.Key.Length == x.Value.Count)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine($"Words found: {wordsFound.Count}");

            wordsFound.ForEach(Console.WriteLine);
        }
    }
}
