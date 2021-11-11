using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; protected set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} ";
        }

        public abstract void ProduceSound();

        public abstract void EatFood(Food food);
    }
}
