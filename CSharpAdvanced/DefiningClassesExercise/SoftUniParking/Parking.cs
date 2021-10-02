using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.Capacity = capacity;
        }

        public IEnumerable<Car> Cars => cars;
        public int Capacity { get => capacity; set => capacity = value; }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == this.Capacity)
            {
                return "Parking is full!";
            }
            this.cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            var car = GetCar(RegistrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(car);

            return $"Successfully removed {RegistrationNumber}";
        }

        public Car GetCar(string RegistrationNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber); 
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            cars = cars.Where(x => !RegistrationNumbers.Contains(x.RegistrationNumber)).ToList();
        }
    }
}
