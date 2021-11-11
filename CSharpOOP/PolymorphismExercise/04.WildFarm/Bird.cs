using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + $"[{this.Name}, {WingSize}, {this.Weight}, {FoodEaten}]";
        }
    }
}
