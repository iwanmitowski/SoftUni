using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _04.Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorNamePhy = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Once upon a time")
            {
                string[] tokens = input.Split(" <:> ");

                string name = tokens[0];
                string color = tokens[1];
                int physics = int.Parse(tokens[2]);

                if (!colorNamePhy.ContainsKey(color))
                {
                    colorNamePhy.Add(color, new Dictionary<string, int>());
                    colorNamePhy[color].Add(name, physics);
                }
                else
                {
                    if (!colorNamePhy[color].ContainsKey(name))
                    {
                        colorNamePhy[color].Add(name, physics);
                    }
                    else
                    {
                        int currentPhysics = colorNamePhy[color][name];

                        if (currentPhysics < physics)
                        {
                            colorNamePhy[color][name] = physics; 
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();

            foreach (var hatColor in colorNamePhy.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }

            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}
