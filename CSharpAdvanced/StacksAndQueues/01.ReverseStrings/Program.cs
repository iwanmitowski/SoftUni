using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>(input.ToCharArray());

            var sb = new StringBuilder();

            while (stack.TryPeek(out _))
            {
                sb.Append(stack.Pop());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
