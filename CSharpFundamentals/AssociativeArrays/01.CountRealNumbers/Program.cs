using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var dictionary = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 0);
                }

                dictionary[number]++;
            }

            foreach ((double number,int count) in dictionary.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{number} -> {count}");
            }

        }
    }
}
