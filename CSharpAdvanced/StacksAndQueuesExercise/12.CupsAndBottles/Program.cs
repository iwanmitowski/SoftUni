using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bottles = new Stack<int>(bottlesInput);
            Queue<int> cups = new Queue<int>(cupsInput);

            int wastedLitters = 0;

            while (bottles.Any() && cups.Any())
            {
                int cup = cups.Dequeue();

                while (cup>0 && bottles.Any())
                {
                    int bottle = bottles.Pop();

                    cup -= bottle;

                    if (cup<0)
                    {
                        wastedLitters += Math.Abs(cup);
                    }
                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ",bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}
