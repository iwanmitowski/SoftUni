using System;
using System.Reflection.Metadata.Ecma335;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(NumberSign(n));
        }

        private static string NumberSign(int n)
        {
            return n == 0 ? $"The number 0 is zero." :
                n < 0 ? $"The number {n} is negative." :
                $"The number {n} is positive.";
        }
    }
}
