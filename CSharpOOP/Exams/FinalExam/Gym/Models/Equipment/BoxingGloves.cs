using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        public const double DefaultWeight = 227;
        public const decimal DefaultPrice = 120;
        public BoxingGloves() : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}
