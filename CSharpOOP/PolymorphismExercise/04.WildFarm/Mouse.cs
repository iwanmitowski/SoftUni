using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        private const double Growth = 0.1;

        public Mouse(string name, double weight, string livingRegion = null) : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void EatFood(Food food)
        {
            var foodType = food.GetType().Name;

            if (foodType != nameof(Vegetable) &&
                foodType != nameof(Fruit))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType}!");
            }

            base.FoodEaten += food.Quantity;
            base.Weight += food.Quantity * Growth;
        }
    }
}
