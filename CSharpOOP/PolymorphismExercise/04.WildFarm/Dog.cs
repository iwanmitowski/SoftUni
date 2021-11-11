using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        private const double Growth = 0.4;

        public Dog(string name, double weight, string livingRegion = null) : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
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
