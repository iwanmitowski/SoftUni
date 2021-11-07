using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age)
        {
            Name = name;
            Age = age;
            Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
