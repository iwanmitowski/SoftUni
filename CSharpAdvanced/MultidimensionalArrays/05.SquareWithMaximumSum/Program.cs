using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int foundRow = -1;
            int foundCol = -1;
            int sum = int.MinValue;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (currentSum > sum)
                    {
                        foundRow = i;
                        foundCol = j;
                        sum = currentSum;
                    }
                }
            }

            Console.WriteLine($"{matrix[foundRow, foundCol]} {matrix[foundRow, foundCol + 1]}");
            Console.WriteLine($"{matrix[foundRow + 1, foundCol]} {matrix[foundRow + 1, foundCol + 1]}");
            Console.WriteLine(sum);
        }
    }
}
