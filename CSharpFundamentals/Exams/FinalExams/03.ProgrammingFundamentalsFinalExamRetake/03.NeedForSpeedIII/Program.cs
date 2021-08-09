using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var carDistanceFuel = new Dictionary<string, int[]>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split("|");
                carDistanceFuel.Add(tokens[0], new int[2] { int.Parse(tokens[1]), int.Parse(tokens[2]) });
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] tokens = input.Split(" : ");

                string command = tokens[0];
                string car = tokens[1];

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(tokens[2]);
                        int fuel = int.Parse(tokens[3]);

                        if (carDistanceFuel[car][1] >= fuel)
                        {
                            carDistanceFuel[car][0] += distance;
                            carDistanceFuel[car][1] -= fuel;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }

                        if (carDistanceFuel[car][0]>100000)
                        {
                            carDistanceFuel.Remove(car);
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                        break;
                    case "Refuel":
                        int refuelFuel = int.Parse(tokens[2]);
                        int carFuel = carDistanceFuel[car][1];

                        carFuel += refuelFuel;
                        if (carFuel > 75)
                        {
                            refuelFuel = 75 - carDistanceFuel[car][1];

                            carDistanceFuel[car][1] = 75;
                        }
                        else
                        {
                            carDistanceFuel[car][1] += refuelFuel;
                        }

                        Console.WriteLine($"{car} refueled with {refuelFuel} liters");
                        break;
                    case "Revert":
                        int kms = int.Parse(tokens[2]);
                        int carKms = carDistanceFuel[car][0];

                        if (carKms - kms >= 10000)
                        {
                            carDistanceFuel[car][0] -= kms;
                            Console.WriteLine($"{car} mileage decreased by {kms} kilometers");
                        }
                        else
                        {
                            carDistanceFuel[car][0] = 10000;
                        }

                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach ((string car, int[] kmsFuel) in carDistanceFuel.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car} -> Mileage: {kmsFuel[0]} kms, Fuel in the tank: {kmsFuel[1]} lt.");
            }

        }
    }
}
