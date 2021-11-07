using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var birthables = new List<IBirthable>();

            while (input != "End")
            {
                var tokens = input.Split();

                if (tokens[0] == "Citizen")
                {
                    birthables.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens[0] == "Pet")
                {
                    birthables.Add(new Pet(tokens[1], tokens[2]));
                }

                input = Console.ReadLine();
            }

            var filterDate = Console.ReadLine();

            var birthdates = birthables
              .Where(x => x.Birthdate.EndsWith(filterDate))
               .Select(x => x.Birthdate)
               .ToList();

            if (birthdates.Any())
            {
                birthdates.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("<empty output>");
            }
        }
    }
}
