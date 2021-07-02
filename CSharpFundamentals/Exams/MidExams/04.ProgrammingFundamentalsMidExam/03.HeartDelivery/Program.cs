using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighbourhood = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            string input = Console.ReadLine();

            int cupid = 0;

            while (input != "Love!")
            {
                int jump = int.Parse(input.Split()[1]);

                if (cupid+jump >= neighbourhood.Count)
                {
                    cupid = 0;
                }
                else
                {
                    cupid += jump;
                }

                if (neighbourhood[cupid]==0)
                {
                    Console.WriteLine($"Place {cupid} already had Valentine's day.");
                    input = Console.ReadLine();
                    continue;
                }

                neighbourhood[cupid] -= 2;

                if (neighbourhood[cupid] == 0)
                {
                    Console.WriteLine($"Place {cupid} has Valentine's day.");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {cupid}.");
            if (neighbourhood.All(x=>x==0))
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int failedHouses = neighbourhood.Where(x => x != 0).Count();
                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }
        }
    }
}
