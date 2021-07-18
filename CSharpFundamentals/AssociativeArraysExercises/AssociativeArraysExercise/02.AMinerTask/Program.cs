using System;
using System.Collections.Generic;
using System.Xml;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string ore = Console.ReadLine();

            var dictionary = new Dictionary<string, int>();

            while (ore!="stop")
            {
                int count = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(ore))
                {
                    dictionary.Add(ore, 0);
                }

                dictionary[ore] += count;

                ore = Console.ReadLine();
            }

            foreach ((string o, int count) in dictionary)
            {
                Console.WriteLine($"{o} -> {count}");
            }
        }
    }
}
