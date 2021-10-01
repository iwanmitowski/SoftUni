using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tiresInput = Console.ReadLine();
            var tires = new List<Tire[]>();

            while (tiresInput != "No more tires")
            {
                var tokens = tiresInput.Split();

                var tiresPairs = new Tire[4];
                int pairCounter = 0;
                for (int i = 0; i < tokens.Length - 1; i += 2)
                {
                    Tire currentTire = new Tire(int.Parse(tokens[i]), double.Parse(tokens[i + 1]));
                    tiresPairs[pairCounter++] = currentTire;
                }

                tires.Add(tiresPairs);

                tiresInput = Console.ReadLine();
            }

            string engineInput = Console.ReadLine();
            var engines = new List<Engine>();

            while (engineInput != "Engines done")
            {
                var tokens = engineInput.Split();

                engines.Add(new Engine(int.Parse(tokens[0]), double.Parse(tokens[1])));

                engineInput = Console.ReadLine();
            }

            string carInput = Console.ReadLine();
            var cars = new List<Car>();

            while (carInput != "Show special")
            {
                var tokens = carInput.Split();

                cars.Add(new Car(
                    tokens[0],
                    tokens[1],
                    int.Parse(tokens[2]),
                    double.Parse(tokens[3]),
                    double.Parse(tokens[4]),
                    engines[int.Parse(tokens[5])],
                    tires[int.Parse(tokens[6])]));

                carInput = Console.ReadLine();
            }

            var specialCars = cars
                .Where(
                x => x.Year >= 2017 &&
                x.Engine.HorsePower > 330 &&
                (x.Tires.Select(x => x.Pressure).Sum() > 9.0 && x.Tires.Select(x => x.Pressure).Sum() <= 10.0))
                .ToList();

            specialCars.ForEach(specialCar =>
            {
                specialCar.Drive(20.0);
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
            );
        }
    }
}
