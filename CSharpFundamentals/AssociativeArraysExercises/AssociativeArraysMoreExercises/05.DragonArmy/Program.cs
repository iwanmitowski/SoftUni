using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorNameAttributes = new Dictionary<string, SortedDictionary<string, List<int>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string color = tokens[0];
                string name = tokens[1];
                int dmg = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
                int hp = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
                int armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

                if (!colorNameAttributes.ContainsKey(color))
                {
                    colorNameAttributes.Add(color, new SortedDictionary<string, List<int>>());
                }

                colorNameAttributes[color].Add(name, new List<int>());
                colorNameAttributes[color][name].Add(dmg);
                colorNameAttributes[color][name].Add(hp);
                colorNameAttributes[color][name].Add(armor);
            }

            foreach ((string color, SortedDictionary<string, List<int>> nameAttributes) in colorNameAttributes)
            {
                double avgDmg = 1.0 * nameAttributes.Values.Select(x => x[0]).Average();
                double avgHp = 1.0 * nameAttributes.Values.Select(x => x[1]).Average(); 
                double avgArmor = 1.0 * nameAttributes.Values.Select(x => x[2]).Average();

                Console.WriteLine($"{color}::({avgDmg:f2}/{avgHp:f2}/{avgArmor:f2})");

                foreach ((string name, List<int> attributes)in nameAttributes)
                {
                    Console.WriteLine($"-{name} -> damage: {attributes[0]}, health: {attributes[1]}, armor: {attributes[2]}");
                }
            }
        }
    }
}
