using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Tiger : Feline
    {
        private const double Growth = 1;

        public Tiger(string name, double weight, string livingRegion, string breed = null) : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
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
