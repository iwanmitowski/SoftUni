using GenericBox;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap(box, indexes[0], indexes[1]);

            Console.WriteLine(box);
        }

        public static void Swap<T>(Box<T> list, int index1, int index2)
        {
            var item1 = list[index1];

            list[index1] = list[index2];

            list[index2] = item1;
        }
    }
}
