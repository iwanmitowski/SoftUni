using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            var townPeopleGold = new Dictionary<string, int[]>();

            string townInput = Console.ReadLine();

            while (townInput != "Sail")
            {
                string[] tokens = townInput.Split("||");

                if (!townPeopleGold.ContainsKey(tokens[0]))
                {
                    townPeopleGold.Add(tokens[0], new int[2]);
                }

                townPeopleGold[tokens[0]][0] += int.Parse(tokens[1]);
                townPeopleGold[tokens[0]][1] += int.Parse(tokens[2]);

                townInput = Console.ReadLine();
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split("=>");
                string command = tokens[0];
                string town = tokens[1];

                switch (command)
                {
                    case "Plunder":
                        int people = int.Parse(tokens[2]);
                        int gold = int.Parse(tokens[3]);
                        townPeopleGold[town][0] -= people;
                        townPeopleGold[town][1] -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (townPeopleGold[town][0] == 0 || townPeopleGold[town][1] == 0)
                        {
                            townPeopleGold.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }

                        break;
                    case "Prosper":
                        gold = int.Parse(tokens[2]);

                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            input = Console.ReadLine();
                            continue;
                        }

                        townPeopleGold[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {townPeopleGold[town][1]} gold.");
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            if (townPeopleGold.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townPeopleGold.Count} wealthy settlements to go to:");

                foreach ((string town, int[] peopleGold) in townPeopleGold.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town} -> Population: {peopleGold[0]} citizens, Gold: {peopleGold[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
          
        }
    }
}
