using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        private const double ACFuelConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + ACFuelConsumption;

        public override string Drive(double distance)
        {
            return base.Drive(distance);
        }
        public string DriveEmpty(double distance)
        {
            var neededFuel = (FuelConsumption - ACFuelConsumption) * distance;

            if (neededFuel <= FuelQuantity)
            {
                FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
    }
}
