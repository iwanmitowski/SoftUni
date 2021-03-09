using System;

namespace _04.TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string symbol = "$ ";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j==i)
                    {
                        Console.Write(symbol.Trim());
                    }
                    else
                    {
                        Console.Write(symbol);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
