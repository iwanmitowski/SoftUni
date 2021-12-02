using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    internal class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return planets.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return planets.Remove(model);
        }
    }
}
