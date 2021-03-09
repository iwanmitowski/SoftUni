using System;

namespace _02_RectangleOfNxNStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string symbol = "*";
            int counter = 0;

            for (int i = 0; i < n*n; i++)
            {
                counter++;
                Console.Write(symbol);
                if (counter==n)
                {
                    Console.WriteLine();
                    counter = 0;
                }
            }
        }
    }
}
