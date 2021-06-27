using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SpeedRacing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TraveledDistance { get; set; }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}";
        }

        public void Drive(double kms)
        {
            if (!CanDrive(kms))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= kms * FuelConsumption;
                TraveledDistance += kms;
            }
        }
        private bool CanDrive(double kms)
        {
            if (kms * FuelConsumption > this.FuelAmount)
            {
                return false;
            }

            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                cars.Add(new Car(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2])));

            }

            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] tokens = input.Split();

                var car = cars.First(x => x.Model == tokens[1]);

                car.Drive(int.Parse(tokens[2]));

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
