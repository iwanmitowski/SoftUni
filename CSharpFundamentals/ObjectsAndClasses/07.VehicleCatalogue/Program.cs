using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace _07.VehicleCatalogue
{
    interface Vehicle
    {
        string Brand {get;}
        string Model {get;}
    }

    class Car : Vehicle
    {
        public Car(string brand, string model, int hp)
        {
            Brand = brand;
            Model = model;
            Hp = hp;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Hp { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Hp}hp";
        }
    }

    class Truck : Vehicle
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    class Catalog
    {
        public Catalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Cars:");
            foreach (var c in this.Cars.OrderBy(x=>x.Brand))
            {
                sb.AppendLine(c.ToString());
            }

            sb.AppendLine("Trucks:");
            foreach (var t in this.Trucks.OrderBy(x => x.Brand))
            {
                sb.AppendLine(t.ToString());
            }

            return sb.ToString().Trim();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();

            string input = Console.ReadLine();

            while (input!="end")
            {
                string[] arguments = input.Split("/");

                if (arguments[0]=="Car")
                {
                    catalog.Cars.Add(new Car(arguments[1], arguments[2], int.Parse(arguments[3])));
                }
                else
                {
                    catalog.Trucks.Add(new Truck(arguments[1], arguments[2], int.Parse(arguments[3])));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(catalog);
        }
    }
}
