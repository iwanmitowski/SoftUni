using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int DefaultDrivingExperience = 10;
        private const string DefaultBehaviour = "aggressive";
        public StreetRacer(string username, ICar car) : base(username, DefaultBehaviour, DefaultDrivingExperience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 5;
            base.Race();
        }
    }
}
