using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {(this.Displacement == null ? "n/a" : this.Displacement.ToString())}");
            sb.AppendLine($"    Efficiency: {(this.Efficiency == null ? "n/a" : this.Efficiency)}");

            return sb.ToString().TrimEnd();
        }
    }
}