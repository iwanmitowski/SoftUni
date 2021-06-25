using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.VehicleCatalogue
{
    interface IVehicle
    {
        string Model { get; set; }
        string Color { get; set; }
        int HorsePower { get; set; }
    }
    abstract class Vehicle : IVehicle
    {
        protected Vehicle(string model, string color, int horsePower)
        {
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePower}");

            return sb.ToString().Trim();
        }
    }

    class Car : Vehicle
    {
        public Car(string model, string color, int horsePower) : base(model, color, horsePower)
        {
        }
    }

    class Truck : Vehicle
    {
        public Truck(string model, string color, int horsePower) : base(model, color, horsePower)
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                string type = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                IVehicle vehicle = type == "car" ? new Car(model, color, horsePower) : new Truck(model, color, horsePower);

                vehicles.Add(vehicle);

                Console.WriteLine(vehicle);

                input = Console.ReadLine();
            }

            string models = Console.ReadLine();

            while (models!= "Close the Catalogue")
            {
                Console.WriteLine(vehicles.First(x=>x.Model== models));

                models = Console.ReadLine();
            }

            double avgCarsHp = vehicles.Where(x => x.GetType().Name == "Car").Select(x => x.HorsePower).Average();
            Console.WriteLine($"Cars have average horsepower of {avgCarsHp:f2}.");

            double avgTrucksHp = vehicles.Where(x => x.GetType().Name == "Truck").Select(x => x.HorsePower).Average();
            Console.WriteLine($"Trucks have average horsepower of {avgTrucksHp:f2}.");

        }
    }
}
