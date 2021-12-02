using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double DefaultOxygen = 70;
        public Biologist(string name) : base(name, DefaultOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 5;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
