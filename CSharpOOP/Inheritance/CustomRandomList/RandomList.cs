using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var element = GetRandomElement();

            this.Remove(element);

            return element;
        }
        private string GetRandomElement()
        {
            var currentIndex = new Random().Next(0, Count);
            return this[currentIndex];
        }
    }
}
