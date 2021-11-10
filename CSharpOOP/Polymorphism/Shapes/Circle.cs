using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => radius;
            
            private set
            {
                if (ValidateValue(value))
                {
                    throw new ArgumentException();
                }
                
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * (this.Radius * this.Radius);
        }

        public override double CalculatePerimeter()
        {
            return this.Radius * 2 * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }

        private bool ValidateValue(double value)
        {
            return value <= 0;
        }
    }
}
