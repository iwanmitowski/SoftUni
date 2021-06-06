using System;
using System.Runtime.CompilerServices;

namespace _05.AddAndSubtract
{
    //Extension methods

    static class MyExtensionMethods
    {
        public static int Sum(this int value, int number)
        {
            return value + number;
        }

        public static int Subtract(this int value, int number)
        {
            return value - number;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int result = n1.Sum(n2).Subtract(n3);

            Console.WriteLine(result);
        }
    }
}
