using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class Animal
    {
        public virtual void Eat()
        {
            Console.WriteLine("eating...");
        }
    }
}
