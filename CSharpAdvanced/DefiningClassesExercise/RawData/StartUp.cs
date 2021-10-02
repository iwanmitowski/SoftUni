using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RawData
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
                Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                Cargo cargo = new Cargo(tokens[4], int.Parse(tokens[3]));

                Tire[] tires = new Tire[4];

                tires[0] = new Tire(int.Parse(tokens[6]), double.Parse(tokens[5]));
                tires[1] = new Tire(int.Parse(tokens[8]), double.Parse(tokens[7]));
                tires[2] = new Tire(int.Parse(tokens[10]), double.Parse(tokens[9]));
                tires[3] = new Tire(int.Parse(tokens[12]), double.Parse(tokens[11]));

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string cargoType = Console.ReadLine();

            List<Car> selectedCars = new List<Car>();

            if (cargoType=="fragile")
            {
                selectedCars = cars
                    .Where(
                        x => x.Cargo.Type == cargoType && x.Tires.Any(x => x.Pressure < 1))
                    .ToList();
            }
            else
            {
                selectedCars = cars
                    .Where(x => x.Cargo.Type == cargoType && x.Engine.Power > 250)
                    .ToList();
            }

            selectedCars.ForEach(Console.WriteLine);
        }
    }
}
