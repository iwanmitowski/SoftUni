using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string name = tokens[1];

                if (command=="register")
                {
                    string number = tokens[2];

                    if (dictionary.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {number}");
                    }
                    else
                    {
                        dictionary.Add(name, number);
                        Console.WriteLine($"{name} registered {number} successfully");
                    }
                }
                else
                {
                    if (!dictionary.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        dictionary.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
