using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        private const double Growth = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void EatFood(Food food)
        {
            var foodType = food.GetType().Name;

            if (foodType != nameof(Meat))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * Growth;
        }
    }
}
