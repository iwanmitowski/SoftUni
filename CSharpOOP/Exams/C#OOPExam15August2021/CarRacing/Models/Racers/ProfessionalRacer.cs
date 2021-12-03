using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DefaultDrivingExperience = 30;
        private const string DefaultBehaviour = "strict";
        public ProfessionalRacer(string username, ICar car) : base(username, DefaultBehaviour, DefaultDrivingExperience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 10;
            base.Race();
        }
    }
}
