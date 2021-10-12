using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double given = double.Parse(Console.ReadLine());

            int count = Count(list, given);

            Console.WriteLine(count);
        }

        private static int Count<T>(List<T> list, T given) where T : IComparable
        {
            int counter = list.Count(x => x.CompareTo(given) > 0);

            return counter;
        }
    }
}
