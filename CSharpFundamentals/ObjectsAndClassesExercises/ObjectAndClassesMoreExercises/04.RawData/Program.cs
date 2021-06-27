using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; set; }
        public int Power { get; set; }
    }
    class Cargo
    {
        public Cargo(int weigth, string type)
        {
            Weigth = weigth;
            Type = type;
        }

        public int Weigth { get; set; }
        public string Type { get; set; }
    }
    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                var engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                var cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);

                cars.Add(new Car(tokens[0], engine, cargo));
            }

            string cargoType = Console.ReadLine();

            cars = cargoType == "fragile" ?
                            cars.Where(c => c.Cargo.Type == cargoType && c.Cargo.Weigth < 1000)
                            .ToList()
                                 :
                            cars.Where(c => c.Cargo.Type == cargoType && c.Engine.Power > 250)
                            .ToList();

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
