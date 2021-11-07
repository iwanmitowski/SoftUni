using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var people = new List<IPerson>();
            var residents = new List<IResident>();

            while (input != "End")
            {
                var tokens = input.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                var citizen = new Citizen(name, country, age);

                people.Add(citizen);
                residents.Add(citizen);

                input = Console.ReadLine();
            }

            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }
        }
    }
}
