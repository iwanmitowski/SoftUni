using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"{this.Engine}");
            sb.AppendLine($"  Weight: {(this.Weight == null ? "n/a" : this.Weight.ToString())}");
            sb.AppendLine($"  Color: {(this.Color == null ? "n/a" : this.Color)}");

            return sb.ToString().TrimEnd();
        }
    }
}
