using System;

namespace _08.FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string engineType = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());

            switch (engineType)
            {
                case "Diesel":
                    PrintResult(engineType, fuelAmount);
                    break;
                case "Gasoline":
                    PrintResult(engineType, fuelAmount);
                    break;
                case "Gas":
                    PrintResult(engineType, fuelAmount);
                    break;

                default:
                    Console.WriteLine("Invalid fuel!");
                    break;
            }
        }

        static void PrintResult(string engineType, double fuelAmount)
        {
            if (fuelAmount >= 25)
            {
                Console.WriteLine($"You have enough {engineType.ToLower()}.");
            }
            else
            {
                Console.WriteLine($"Fill your tank with {engineType.ToLower()}!");

            }
        }
    }
}
