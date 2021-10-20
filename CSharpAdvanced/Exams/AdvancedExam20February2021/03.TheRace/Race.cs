using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private readonly List<Racer> racers;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.racers.Count;
        public void Add(Racer racer)
        {
            if (Count == Capacity)
            {
                throw new InvalidOperationException();
            }

            this.racers.Add(racer);
        }

        public bool Remove(string name)
        {
            var racer = GetRacer(name);

            if (racer == null)
            {
                return false;
            }

            return true;
        }

        public Racer GetOldestRacer()
        {
            return this.racers.OrderByDescending(x => x.Age).First();
        }

        public Racer GetRacer(string name)
        {
            return this.racers.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return this.racers.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.ToString());

            foreach (var racer in this.racers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Racers participating at {this.Name}:";
        }
    }
}
