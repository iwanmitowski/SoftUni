using System;
using System.Numerics;

namespace _02.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger fact = 2;

            for (int i = 3; i <= n; i++)
            {
                fact *= i;
            }

            Console.WriteLine(fact);
        }
    }
}
