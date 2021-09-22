using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int mainDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                mainDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[n - i - 1, i];
            }

            Console.WriteLine(Math.Abs(mainDiagonal - secondaryDiagonal));
        }
    }
}
