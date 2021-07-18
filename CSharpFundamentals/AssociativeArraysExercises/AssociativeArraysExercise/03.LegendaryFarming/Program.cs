using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>();
            var junk = new Dictionary<string, int>();
            materials.Add("shards", 0);
            materials.Add("fragments", 0);
            materials.Add("motes", 0);

            bool isCrafted = false;
            string crafted = string.Empty;

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                string[] tokens = input.Split();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int quantity = int.Parse(tokens[i]);
                    string material = tokens[i + 1];

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        materials[material] += quantity;

                        if (materials["shards"] >= 250)
                        {
                            isCrafted = true;
                            crafted = "Shadowmourne";
                        }
                        else if (materials["fragments"] >= 250)
                        {
                            isCrafted = true;
                            crafted = "Valanyr";
                        }
                        else if (materials["motes"] >= 250)
                        {
                            isCrafted = true;
                            crafted = "Dragonwrath";
                        }

                        if (isCrafted)
                        {
                            materials[material] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(material))
                        {
                            junk.Add(material, 0);
                        }

                        junk[material] += quantity;
                    }
                }

                if (isCrafted)
                {
                    break;
                }
            }

            Console.WriteLine($"{crafted} obtained!");

            foreach ((string material, int count) in materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{material}: {count}");
            }

            foreach ((string material, int count) in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{material}: {count}");
            }
        }
    }
}
