using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var num in numbers)
            {
                if (!dictionary.ContainsKey(num))
                {
                    dictionary.Add(num, 0);
                }

                dictionary[num]++;
            }

            foreach ((double number, int count) in dictionary)
            {
                Console.WriteLine($"{number} - {count} times");
            }
        }
    }
}
