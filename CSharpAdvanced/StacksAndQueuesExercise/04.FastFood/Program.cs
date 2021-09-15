using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            Queue<int> queue = new Queue<int>(orders);

            int maxOrder = queue.Max();

            while (queue.Any())
            {
                int currentOrder = queue.Peek();

                if (quantity >= currentOrder)
                {
                    queue.Dequeue();

                    if (maxOrder < currentOrder)
                    {
                        maxOrder = currentOrder;
                    }

                    quantity -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(maxOrder);

            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
