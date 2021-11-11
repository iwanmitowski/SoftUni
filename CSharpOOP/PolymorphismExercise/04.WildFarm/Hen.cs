using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        private const double Growth = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void EatFood(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += food.Quantity * Growth;
        }
    }
}
