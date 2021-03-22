using System;

namespace _02.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string raceType = Console.ReadLine();

            decimal totalSum = 0;

            decimal juniorsPrice = 0;
            decimal seniorsPrice = 0;

            if (raceType == "trail")
            {
                juniorsPrice = 5.5M;
                seniorsPrice = 7;
            }
            else if (raceType == "cross-country")
            {
                juniorsPrice = 8;
                seniorsPrice = 9.5M;
                if (juniors + seniors >= 50)
                {
                    juniorsPrice *= 0.75M;
                    seniorsPrice *= 0.75M;
                }
            }
            else if (raceType == "downhill")
            {
                juniorsPrice = 12.25M;
                seniorsPrice = 13.75M;
            }
            else if (raceType == "road")
            {
                juniorsPrice = 20;
                seniorsPrice = 21.50M;
            }

            totalSum = seniors * seniorsPrice + juniors * juniorsPrice;
            totalSum *= 0.95M;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
