using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<double>>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] tokens = input.Split();

                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                double quanity = double.Parse(tokens[2]);

                if (!dictionary.ContainsKey(product))
                {
                    dictionary.Add(product, new List<double>() { price, quanity });
                }
                else
                {
                    dictionary[product][0] = price;
                    dictionary[product][1] += quanity;
                }

                input = Console.ReadLine();
            }

            foreach ((string product, List<double> characteristics) in dictionary)
            {
                Console.WriteLine($"{product} -> {characteristics[0] * characteristics[1]:f2}");
            }
        }
    }
}
