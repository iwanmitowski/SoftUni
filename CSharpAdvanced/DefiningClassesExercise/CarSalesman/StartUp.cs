using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine());

            var engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                var currentEngine = new Engine(model, power);

                if (tokens.Length > 2)
                {
                    if (int.TryParse(tokens[2], out _))
                    {
                        currentEngine.Displacement = int.Parse(tokens[2]);
                    }
                    else
                    {
                        currentEngine.Efficiency = tokens[2];
                    }
                }

                if (tokens.Length > 3)
                {
                    if (int.TryParse(tokens[3], out _))
                    {
                        currentEngine.Displacement = int.Parse(tokens[3]);
                    }
                    else
                    {
                        currentEngine.Efficiency = tokens[3];
                    }
                }

                engines.Add(currentEngine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[0];
                var engine = engines.FirstOrDefault(x => x.Model == tokens[1]);

                var currentCar = new Car(carModel, engine);

                if (tokens.Length > 2)
                {
                    if (int.TryParse(tokens[2], out _))
                    {
                        currentCar.Weight = int.Parse(tokens[2]);
                    }
                    else
                    {
                        currentCar.Color = tokens[2];
                    }
                }

                if (tokens.Length > 3)
                {
                    if (int.TryParse(tokens[3], out _))
                    {
                        currentCar.Weight = int.Parse(tokens[3]);
                    }
                    else
                    {
                        currentCar.Color = tokens[3];
                    }
                }

                cars.Add(currentCar);
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
