using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        public static string[,] matrix;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Count() == 5 && tokens[0] == "swap")
                {
                    int[] coordinates = tokens.Skip(1).Select(int.Parse).ToArray();

                    if (AreValidCoordinates(coordinates))
                    {
                        var currentValue = matrix[coordinates[0], coordinates[1]];

                        matrix[coordinates[0], coordinates[1]] = matrix[coordinates[2], coordinates[3]];
                        matrix[coordinates[2], coordinates[3]] = currentValue;

                        PrintMatrix();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreValidCoordinates(int[] coordinates)
        {
            int row1 = coordinates[0];
            int col1 = coordinates[1];
            int row2 = coordinates[2];
            int col2 = coordinates[3];

            return row1 >= 0 && row1 < matrix.GetLength(0) &&
                   col1 >= 0 && col1 < matrix.GetLength(1) &&
                   row2 >= 0 && row2 < matrix.GetLength(0) &&
                   col2 >= 0 && col2 < matrix.GetLength(1);
        }
    }
}
