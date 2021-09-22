using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] letters = Console.ReadLine().Split();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = letters[j];
                }
            }

            int squares = 0;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i, j] == matrix[i + 1, j] &&
                        matrix[i, j + 1] == matrix[i + 1, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        squares++;
                    }
                }
            }

            Console.WriteLine(squares);
        }
    }
}
