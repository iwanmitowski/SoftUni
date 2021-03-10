using System;

namespace _06.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbol = "*";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(" ");
                }

                Console.Write(symbol);

                for (int k = 0; k <= i - 1; k++)
                {
                    Console.Write(" " + symbol);
                }
                Console.WriteLine();
            }



            for (int i = 2; i <= n ; i++)
            {
                for (int k = 0; k < i - 1; k++)
                {
                    Console.Write(" ");
                }

                Console.Write(symbol);

                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(" " + symbol);
                }
                Console.WriteLine();
            }
        }
    }
}
