using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumption = double.Parse(tokens[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));

            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split().Skip(1).ToArray();
                string model = tokens[0];
                double distance = double.Parse(tokens[1]);

                var car = cars.FirstOrDefault(x => x.Model == model);

                car.Drive(distance);

                input = Console.ReadLine();
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
