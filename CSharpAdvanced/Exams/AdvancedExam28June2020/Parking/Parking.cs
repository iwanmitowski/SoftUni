using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        private readonly List<Car> cars;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            this.cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.cars.Count;

        public void Add(Car car)
        {
            if (this.Count == this.Capacity)
            {
                throw new InvalidOperationException();
            }

            this.cars.Add(car);
        }

        public bool Remove(string manufacturer, string model)
        {
            var car = GetCar(manufacturer, model);

            return this.cars.Remove(car);
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public Car GetLatestCar()
        {
            return this.cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in this.cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
