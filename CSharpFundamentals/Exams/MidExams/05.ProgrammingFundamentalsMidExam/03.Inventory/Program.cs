using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] tokens = input.Split(" - ");

                string command = tokens[0];
                string material = tokens[1];

                switch (command)
                {
                    case "Collect":
                        if (!items.Contains(material))
                        {
                            items.Add(material);
                        }
                        break;
                    case "Drop":
                        if (items.Contains(material))
                        {
                            items.Remove(material);
                        }
                        break;
                    case "Combine Items":
                        string[] currentItems = material.Split(":");
                        string oldMaterial = currentItems[0];
                        string newMaterial = currentItems[1];

                        if (items.Contains(oldMaterial))
                        {
                            int index = items.IndexOf(oldMaterial);
                            items.Insert(index + 1, newMaterial);
                        }
                        break;
                    case "Renew":
                        if (items.Contains(material))
                        {
                            items.Remove(material);
                            items.Add(material);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
