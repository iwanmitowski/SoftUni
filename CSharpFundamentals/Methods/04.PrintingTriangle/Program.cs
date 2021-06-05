using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        //Recursive solution

        private static int n;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            Print(1);
        }

        private static void Print(int i)
        {
            if (i == n + 1)
            {
                return;
            }

            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }

            Console.WriteLine();

            Print(i + 1);

            for (int j = 1; j < i; j++)
            {
                Console.Write(j + " ");
            }

            if (i!=1)
            {
                Console.WriteLine();
            }
        }
    }
}
