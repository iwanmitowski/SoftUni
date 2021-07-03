using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|").ToList();

            string input = Console.ReadLine(); ;

            while (input != "Yohoho!")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Loot":
                        for (int i = 1; i < tokens.Length; i++)
                        {
                            if (!items.Contains(tokens[i]))
                            {
                                items.Insert(0, tokens[i]);
                            }
                        }
                        break;
                    case "Drop":
                        int index = int.Parse(tokens[1]);
                        if (index > 0 && index <= items.Count)
                        {
                            items.Add(items[index]);
                            items.RemoveAt(index);

                        }
                        break;
                    case "Steal":
                        List<string> stolen = new List<string>();

                        int count = int.Parse(tokens[1]);

                        for (int i = 0; i < count; i++)
                        {
                            stolen.Add(items.Last());
                            items.RemoveAt(items.Count - 1);

                            if (items.Count==0)
                            {
                                break;
                            }
                        }

                        stolen.Reverse();
                        Console.WriteLine(string.Join(", ",stolen));
                        break;
                }

                input = Console.ReadLine();
            }

            if (items.Any())
            {
                double averageGain = items.Select(x => x.Length).Average();
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            
        }
    }
}
