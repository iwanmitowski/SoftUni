using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
            FuelConsumption = DefaultFuelConsumption;
        }

        public int HorsePower { get; private set; }
        public double Fuel { get; private set; }
        public virtual double FuelConsumption { get; protected set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= FuelConsumption * kilometers;

            if (this.Fuel < 0)
            {
                this.Fuel = 0;
            }
        }
    }
}
