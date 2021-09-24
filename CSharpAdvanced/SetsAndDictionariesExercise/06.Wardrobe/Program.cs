using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];

                List<string> clothes = input.Last().Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[color].ContainsKey(cloth))
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] lookingFor = Console.ReadLine().Split();

            string lookingColor = lookingFor[0];
            string lookingCloth = lookingFor[1];

            foreach ((string color, Dictionary<string, int> clothesCount) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");

                foreach ((string cloth, int count) in clothesCount)
                {
                    if (color == lookingColor && cloth == lookingCloth)
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }


        }
    }
}
