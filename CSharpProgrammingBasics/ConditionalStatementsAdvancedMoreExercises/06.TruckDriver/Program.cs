using System;

namespace _06.TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            decimal kmsPerMonth = decimal.Parse(Console.ReadLine());

            decimal lvPerKm = 0;

            if (kmsPerMonth<=5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        lvPerKm = 0.75M;
                        break;
                    case "Summer":
                        lvPerKm = 0.9M;
                        break;
                    case "Winter":
                        lvPerKm = 1.05M;
                        break;
                    default:
                        break;
                }
            }
            else if (kmsPerMonth>5000&&kmsPerMonth<=10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        lvPerKm = 0.95M;
                        break;
                    case "Summer":
                        lvPerKm = 1.1M;
                        break;
                    case "Winter":
                        lvPerKm = 1.25M;
                        break;
                    default:
                        break;
                }
            }
            else if (kmsPerMonth>10000&&kmsPerMonth<=20000)
            {
                lvPerKm = 1.45M;

            }

            decimal totalSum = (lvPerKm *kmsPerMonth) * 4;
            totalSum *= 0.9M;

            Console.WriteLine($"{totalSum:f2}");

        }
    }
}
