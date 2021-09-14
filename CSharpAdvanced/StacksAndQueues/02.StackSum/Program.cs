using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine().ToLower();

            var stack = new Stack<int>(numbers);

            while (input != "end")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                int[] values = tokens.Skip(1).Select(int.Parse).ToArray();

                switch (command)
                {
                    case "add":
                        foreach (var item in values)
                        {
                            stack.Push(item);
                        }
                        break;
                    default:
                        if (stack.Count() >= values[0])
                        {
                            for (int i = 0; i < values[0]; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }

                input = Console.ReadLine().ToLower();
            }

            int sum = stack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
