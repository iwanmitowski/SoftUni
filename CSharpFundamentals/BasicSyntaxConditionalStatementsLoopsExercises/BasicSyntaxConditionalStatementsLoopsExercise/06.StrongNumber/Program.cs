using System;
using System.Linq;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            string[] digits = number.ToCharArray().Select(x => x.ToString()).ToArray();

            int factorialSum = 0;

            foreach (var digit in digits)
            {
                int fact = 1;
                for (int i = 1; i <= int.Parse(digit); i++)
                {
                    fact *= i;
                }
                factorialSum += fact;

                if (factorialSum>int.Parse(number))
                {
                    break;
                }
            }

            if (factorialSum==int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine($"no");
            }
        }
    }
}
