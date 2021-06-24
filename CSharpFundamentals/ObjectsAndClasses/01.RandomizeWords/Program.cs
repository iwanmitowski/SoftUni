using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            Random rnd = new Random();
            List<string> result = new List<string>();
            while (words.Count!=0)
            {
                int index = rnd.Next(0, words.Count);
                result.Add(words[index]);
                words.RemoveAt(index);
            }
            Console.WriteLine(string.Join(Environment.NewLine,result));
            
        }
    }
}
