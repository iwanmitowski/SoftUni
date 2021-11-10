using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height
        {
            get => height; 
            
            private set
            {
                if (ValidateValue(value))
                {
                    throw new ArgumentException();
                }

                height = value;
            }
        }

        public double Width
        {
            get => width;

            private set
            {
                if (ValidateValue(value))
                {
                    throw new ArgumentException();
                }

                width = value;
            }
        }


        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
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
