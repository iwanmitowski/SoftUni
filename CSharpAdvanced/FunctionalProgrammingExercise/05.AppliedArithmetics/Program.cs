using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            Func<int, int> arithmeticOperation = null;
            Action printer = () => Console.WriteLine(string.Join(" ", numbers));

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        arithmeticOperation = x => x + 1;
                        break;
                    case "multiply":
                        arithmeticOperation = x => x * 2;
                        break;
                    case "subtract":
                        arithmeticOperation = x => x - 1;
                        break;
                    case "print":
                        printer();
                        break;
                }

                numbers = numbers.Select(arithmeticOperation).ToList();

                input = Console.ReadLine();
            }
        }
    }
}
