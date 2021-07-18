using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //side users
            var dictionary = new Dictionary<string, List<string>>();
            var users = new List<string>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                string forceSide = string.Empty;
                string forceUser = string.Empty;
                bool isContained = false;
                if (input.Contains(" | "))
                {
                    string[] tokens = input.Split(" | ");

                    forceSide = tokens[0];
                    forceUser = tokens[1];

                    if (!dictionary.ContainsKey(forceSide))
                    {
                        dictionary.Add(forceSide, new List<string>());
                    }

                    foreach (var fs in dictionary)
                    {
                        if (fs.Value.Contains(forceUser))
                        {
                            isContained = true;
                            break;
                        }
                    }

                    if (!isContained)
                    {
                        dictionary[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ");

                    forceSide = tokens[1];
                    forceUser = tokens[0];

                    if (!dictionary.ContainsKey(forceSide))
                    {
                        dictionary.Add(forceSide, new List<string>());
                    }

                    foreach (var fs in dictionary)
                    {
                        if (fs.Value.Contains(forceUser))
                        {
                            fs.Value.Remove(forceUser);
                            break;
                        }
                    }

                    dictionary[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach ((string forceSide, List<string> forceUsers) in dictionary
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {forceSide}, Members: {forceUsers.Count}");
                foreach (var user in forceUsers.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }

        }
    }
}
