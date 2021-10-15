using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<string>(
                input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToList());

            input = Console.ReadLine();

            while (input != "END")
            {
                List<string> tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = tokens[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            stack.Push(tokens[1]);
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                input = Console.ReadLine();
            }

            if (stack.Any())
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (var element in stack)
                    {
                        Console.WriteLine(element);
                    }
                }
            }


        }
    }
}