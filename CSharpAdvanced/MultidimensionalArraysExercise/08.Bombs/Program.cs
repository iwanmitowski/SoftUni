using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            string[] bombCoordinates = Console.ReadLine().Split();

            foreach (var coord in bombCoordinates)
            {
                int[] bombTokens = coord.Split(",").Select(int.Parse).ToArray();

                int row = bombTokens[0];
                int col = bombTokens[1];

                int value = matrix[row, col];

                Explode(row, col, value, matrix);
            }

            List<int> flatMatrix = matrix.Cast<int>().ToList();

            int aliveCells = flatMatrix.Count(x => x > 0);
            int sum = flatMatrix.Where(x => x > 0).Sum();

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void Explode(int row, int col, int value, int[,] matrix)
        {
            for (int i = row - 1; i < row + 2; i++)
            {
                if (i < 0)
                {
                    continue;
                }

                for (int j = col - 1; j < col + 2; j++)
                {
                    if (i == row && j == col && matrix[i, j] > 0)
                    {
                        matrix[i, j] = 0;
                    }
                    else if (i >= 0 && i < matrix.GetLength(0) &&
                             j >= 0 && j < matrix.GetLength(0) &&
                             matrix[i, j] > 0 && 
                             matrix[row,col] >= 0)
                    {
                        matrix[i, j] -= value;
                    }
                }
            }
        }
    }
}
