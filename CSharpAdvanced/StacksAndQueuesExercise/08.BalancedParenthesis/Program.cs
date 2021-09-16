using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> opening = new Stack<char>();

            foreach (var c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    opening.Push(c);
                }
                else
                {
                    if (!opening.Any())
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }

                    char popped = opening.Peek();

                    if (popped == '(' && c == ')' ||
                        popped == '[' && c == ']' ||
                        popped == '{' && c == '}')
                    {
                        opening.Pop();
                    }
                }
            }

            if (opening.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
