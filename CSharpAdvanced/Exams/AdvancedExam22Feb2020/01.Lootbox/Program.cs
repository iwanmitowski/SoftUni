using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int sum = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                var first = firstBox.Peek();
                var second = secondBox.Pop();

                int currentSum = first + second;

                if (currentSum % 2 == 0)
                {
                    sum += currentSum;
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(second);
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum < 100)
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
        }
    }
}
