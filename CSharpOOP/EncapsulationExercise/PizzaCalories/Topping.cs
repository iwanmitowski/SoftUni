using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int BaseCalouriesValue = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private readonly IReadOnlyDictionary<string, double> toppingTypes;
        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            toppingTypes = FillToppingTypesDictionary();
            ToppingType = toppingType;
            Grams = grams;
        }

        public string ToppingType
        {
            get => toppingType;

            private set
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double Grams
        {
            get => grams;

            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                grams = value;
            }
        }
        public int BaseCalories => BaseCalouriesValue;
        public double ToppingCalories => GetToppingCaloriesValue();
        public double TotalCalories => BaseCalories * ToppingCalories * Grams;

        private IReadOnlyDictionary<string, double> FillToppingTypesDictionary()
        {
            var dictionary = new Dictionary<string, double>
            {
                ["meat"] = 1.2,
                ["veggies"] = 0.8,
                ["cheese"] = 1.1,
                ["sauce"] = 0.9
            };

            return dictionary;
        }
        private double GetToppingCaloriesValue()
        {
            return toppingTypes[this.ToppingType.ToLower()];
        }
    }
}
