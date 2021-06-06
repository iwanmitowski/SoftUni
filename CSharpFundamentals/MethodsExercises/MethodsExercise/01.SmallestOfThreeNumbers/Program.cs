using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            Console.WriteLine(Smallest(n1,n2,n3));
        }

        private static int Smallest(int n1, int n2, int n3)
        {
            return Math.Min(n1, Math.Min(n2, n3));
        }
    }
}
