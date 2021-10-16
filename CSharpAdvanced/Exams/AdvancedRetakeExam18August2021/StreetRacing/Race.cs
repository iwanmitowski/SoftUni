using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public List<Car> Participants
        {
            get { return participants; }
            private set { participants = value; }
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (this.Participants.Any(x => x.LicensePlate == car.LicensePlate))
            {
                throw new InvalidOperationException();
            }

            if (this.Count >= this.Capacity)
            {
                throw new InvalidOperationException();
            }

            if (car.HorsePower > this.MaxHorsePower)
            {
                throw new InvalidOperationException();
            }

            this.Participants.Add(car);
        }

        public bool Remove(string licensePlate)
        {
            var car = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (car == null)
            {
                return false;
            }

            this.Participants.Remove(car);

            return true;
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return this.Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.ToString());

            foreach (var participant in this.Participants)
            {
                sb.AppendLine(participant.ToString());
            }

            return sb.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Race: {Name} - Type: {Type} (Laps: {Laps})";
        }
    }
}
