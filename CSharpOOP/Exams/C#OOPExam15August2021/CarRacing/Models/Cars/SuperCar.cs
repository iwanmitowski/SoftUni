using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        public const double DefaultFuelAvailable = 80;
        public const double DefaultFuelConsumption = 10;

        public SuperCar(string make, string model, string vIN, int horsePower) : base(make, model, vIN, horsePower, DefaultFuelAvailable, DefaultFuelConsumption)
        {
        }
    }
}
