using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    var planetItem = planet.Items.FirstOrDefault();
                    planet.Items.Remove(planetItem);

                    astronaut.Breath();

                    astronaut.Bag.Items.Add(planetItem);
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }
        }
    }
}
