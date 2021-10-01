using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make
        {
            get => make;
            set
            {
                make = value;
            }
        }
        public string Model
        {
            get => model;
            set
            {
                model = value;
            }
        }
        public int Year
        {
            get => year;
            set
            {
                year = value;
            }
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => fuelConsumption;
            set
            {
                fuelConsumption = value;
            }
        }

        public Engine Engine
        {
            get => engine;
            set
            {
                engine = value;
            }
        }

        public Tire[] Tires
        {
            get => tires;
            set
            {
                tires = value;
            }
        }

        public void Drive(double distance)
        {
            double consumedFuel = distance * (this.FuelConsumption / 100);
            if (this.FuelQuantity - consumedFuel < 0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
                return;
            }

            this.FuelQuantity -= consumedFuel;
        }

        public string WhoAmI()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Make: " + this.Make);
            sb.AppendLine("Model: " + this.Model);
            sb.AppendLine("Year: " + this.Year);
            sb.AppendLine("Fuel: " + this.FuelQuantity.ToString("f2"));

            return sb.ToString().Trim();
        }

    }
}
