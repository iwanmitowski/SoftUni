using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            var arr = new T[length];
            Array.Fill(arr, item);

            return arr;
        }
    }
}
