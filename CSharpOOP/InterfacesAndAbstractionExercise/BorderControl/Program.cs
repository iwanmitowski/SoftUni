using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            //04

            //var migrants = new List<IIdentifyable>();

            //string input = Console.ReadLine();

            //while (input != "End")
            //{
            //    var tokens = input.Split();

            //    if (tokens.Length == 3)
            //    {
            //        migrants.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
            //    }
            //    else
            //    {
            //        migrants.Add(new Robot(tokens[0], tokens[1]));
            //    }

            //    input = Console.ReadLine();
            //}

            //string fakeId = Console.ReadLine();

            //migrants
            //   .Where(x => x.Id.EndsWith(fakeId))
            //    .Select(x => x.Id)
            //    .ToList()
            //    .ForEach(Console.WriteLine);


            //05

            //string input = Console.ReadLine();

            //var birthables = new List<IBirthable>();

            //while (input != "End")
            //{
            //    var tokens = input.Split();

            //    if (tokens[0] == "Citizen")
            //    {
            //        birthables.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
            //    }
            //    else if (tokens[0] == "Pet")
            //    {
            //        birthables.Add(new Pet(tokens[1], tokens[2]));
            //    }

            //    input = Console.ReadLine();
            //}

            //var filterDate = Console.ReadLine();

            //foreach (var birthdate in birthables)
            //{
            //    Console.WriteLine(birthdate.Birthdate);
            //}

            //06

            int n = int.Parse(Console.ReadLine());

            var buyers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(tokens[0], int.Parse(tokens[1])));
                }
                else
                {
                    buyers.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                var buyer = buyers.FirstOrDefault(x => x.Name == input);

                if (buyer == null)
                {
                    input = Console.ReadLine();
                    continue;
                }

                buyer.BuyFood();

                input = Console.ReadLine();
            }

            var totalFood = buyers.Sum(x => x.Food);
            Console.WriteLine(totalFood);
        }
    }
}
