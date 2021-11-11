using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        private const double Growth = 0.3;

        public Cat(string name, double weight, string livingRegion = null, string breed = null) : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override void EatFood(Food food)
        {
            var foodType = food.GetType().Name;

            if (foodType != nameof(Vegetable) &&
                foodType != nameof(Meat))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * Growth;
        }
    }
}
