using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var numbers = new Stack<string>(input);

            int sum = 0;

            while (numbers.Any())
            {
                string digit = numbers.Pop();
                string sign = string.Empty;
                numbers.TryPop(out sign);

                int number = int.Parse($"{sign}{digit}");

                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
