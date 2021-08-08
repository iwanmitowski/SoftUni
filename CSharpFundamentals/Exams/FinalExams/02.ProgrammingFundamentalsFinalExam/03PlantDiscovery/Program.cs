using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            var plantRarityRating = new Dictionary<string, List<double>>();
            var plantRating = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("<->");

                plantRarityRating.Add(tokens[0], new List<double>() { int.Parse(tokens[1]) });
                plantRating.Add(tokens[0], new List<int>());
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] tokens = input.Split(new char[] { ' ', '-', ':' },StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string plant = tokens[1];

                if (!plantRarityRating.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                }
                else
                {
                    switch (command)
                    {
                        case "Rate":
                            plantRating[plant].Add(int.Parse(tokens[2]));
                            break;
                        case "Update":
                            plantRarityRating[plant][0] = int.Parse(tokens[2]);
                            break;
                        case "Reset":
                            plantRating[plant].Clear();
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                }

                input = Console.ReadLine();
            }

            foreach ((string plant, List<int> rating) in plantRating)
            {
                double count = rating.Count();

                plantRarityRating[plant].Add(count == 0 ? 0 : rating.Average());
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach ((string plant, List<double> rarityRating) in plantRarityRating.OrderByDescending(x => x.Value[0]).ThenByDescending(x => x.Value[1]))
            {
                Console.WriteLine($"- {plant}; Rarity: {rarityRating[0]}; Rating: {rarityRating[1]:f2}");
            }

        }
    }
}
