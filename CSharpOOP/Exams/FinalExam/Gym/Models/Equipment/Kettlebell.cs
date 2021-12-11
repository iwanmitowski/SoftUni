using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        public const double DefaultWeight = 10000;
        public const decimal DefaultPrice = 80;
        public Kettlebell() : base(DefaultWeight, DefaultPrice)
        {
        }
    }
}
