using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!world.ContainsKey(continent))
                {
                    world.Add(continent, new Dictionary<string, List<string>>());

                    world[continent].Add(country, new List<string>());
                }
                else
                {
                    if (!world[continent].ContainsKey(country))
                    {
                        world[continent].Add(country, new List<string>());
                    }
                }

                world[continent][country].Add(city);
            }

            foreach ((string continent, Dictionary<string, List<string>> countries) in world)
            {
                Console.WriteLine($"{continent}:");
                foreach ((string country, List<string> cities )in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ",cities)}");
                }
            }
        }
    }
}
