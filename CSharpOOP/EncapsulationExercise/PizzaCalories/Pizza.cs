using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLenght = 1;
        private const int MaxNameLenght = 15;
        private const int MinTopings = 0;
        private const int MaxTopings = 10;

        private readonly HashSet<Topping> toppings;
        private string name;

        public Pizza(string name, Dough dough)
        {
            toppings = new HashSet<Topping>();
            Name = name;
            Dough = dough;
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || 
                    value.Length < MinNameLenght ||
                    value.Length > MaxNameLenght)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLenght} and {MaxNameLenght} symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; private set; }
        public double TotalCalories => Dough.TotalCalories + toppings.Sum(x => x.TotalCalories);

        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);

            if (toppings.Count > MaxTopings)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [{MinTopings}..{MaxTopings}].");
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
