using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get => minValue; set => minValue = value; }
        public int MaxValue { get => maxValue; set => maxValue = value; }

        public override bool IsValid(object obj)
        {
            int value;

            if (int.TryParse(obj.ToString(), out value) &&
                value >= minValue &&
                value <= maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
