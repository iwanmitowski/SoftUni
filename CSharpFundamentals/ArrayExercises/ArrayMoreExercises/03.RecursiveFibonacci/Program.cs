using System;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        private static long[] foundNumbers;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            foundNumbers = new long[n+1];
            Fibonacci(n);
            Console.WriteLine(foundNumbers[n]);
        }

        private static long Fibonacci(int index)
        {
            if (foundNumbers[index]!=0)
            {
                return foundNumbers[index];
            }

            if (index <=2)
            {
                foundNumbers[index] = 1;
                return foundNumbers[index];
            }

            foundNumbers[index] = Fibonacci(index - 1) + Fibonacci(index - 2);

            return foundNumbers[index];
        }
    }
}
