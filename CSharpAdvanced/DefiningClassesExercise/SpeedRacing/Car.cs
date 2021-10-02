using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double Travelleddistance { get; set; } = 0;

        public void Drive(double distance)
        {
            var neededFuel = distance * FuelConsumptionPerKilometer ;

            if (this.FuelAmount < neededFuel )
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.FuelAmount -= neededFuel;
            this.Travelleddistance += distance;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.Travelleddistance}";
        }
    }
}
