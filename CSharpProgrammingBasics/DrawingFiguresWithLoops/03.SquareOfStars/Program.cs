using System;

namespace _03.SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string symbol = "* ";
            int counter = 0;

            for (int i = 0; i < n * n; i++)
            {
                counter++;
               
               
                if (counter == n)
                {
                    Console.Write(symbol.Trim());
                    Console.WriteLine();
                    counter = 0;
                }
                else
                {
                    Console.Write(symbol);
                }
            }
        }
    }
}
