using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T, U>
    {
        public Tuple(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public T Item1 { get; set; }
        public U Item2 { get; set; }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
