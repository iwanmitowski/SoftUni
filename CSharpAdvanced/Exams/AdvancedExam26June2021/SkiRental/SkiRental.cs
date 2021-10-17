using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private readonly List<Ski> ski;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.ski = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.ski.Count;

        public void Add(Ski ski)
        {
            if (this.Count == this.Capacity)
            {
                throw new InvalidOperationException();
            }

            this.ski.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            var ski = GetSki(manufacturer, model);

            if (ski == null)
            {
                return false;
            }

            this.ski.Remove(ski);

            return true;
        }

        public Ski GetNewestSki()
        {
            return this.ski.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return this.ski.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.ToString());
            foreach (var ski in this.ski)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"The skis stored in {this.Name}:";
        }
    }
}
