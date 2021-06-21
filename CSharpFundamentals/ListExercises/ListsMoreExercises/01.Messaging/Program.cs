using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            List<char> text = Console.ReadLine().ToCharArray().ToList();

            foreach (var number in numbers)
            {
                int currentSum = number.Select(x => int.Parse(x.ToString())).Sum();
                if (currentSum>=text.Count)
                {
                    currentSum /= text.Count;
                }

                Console.Write(text[currentSum]);

                text.RemoveAt(currentSum);
            }
        }
    }
}
