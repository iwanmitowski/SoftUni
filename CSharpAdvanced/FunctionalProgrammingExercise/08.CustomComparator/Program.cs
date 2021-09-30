using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _08.CustomComparator
{
    class ArraySorter : IComparer<int>
    {

        public int[] Numbers { get; set; }

        public ArraySorter(int[] numbers)
        {
            Numbers = numbers;
        }

        public int Compare(int x, int y)
        {

            if (x == y)
            {
                return 0;
            }
            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            return x > y ? 1 : -1;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            IComparer<int> comparer = new ArraySorter(numbers);
            Array.Sort(numbers, comparer);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
