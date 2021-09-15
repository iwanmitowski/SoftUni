using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] values = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (values[0] == 1)
                {
                    stack.Push(values[1]);
                }
                else if (values[0] == 2)
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (values[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
