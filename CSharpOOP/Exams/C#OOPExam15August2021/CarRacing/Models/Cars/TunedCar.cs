using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public const double DefaultFuelAvailable = 65;
        public const double DefaultFuelConsumption = 7.5;
        public TunedCar(string make, string model, string vIN, int horsePower) : base(make, model, vIN, horsePower, DefaultFuelAvailable, DefaultFuelConsumption)
        {
        }

        public override void Drive()
        {
            this.HorsePower -= (int)Math.Round(this.HorsePower * 0.03);
            base.Drive();
        }
    }
}
