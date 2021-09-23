using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;
            HashSet<string> bunnies = new HashSet<string>();

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < cols; j++)
                {
                    if (input[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    else if (input[j] == 'B')
                    {
                        bunnies.Add($"{i},{j}");
                    }

                    matrix[i, j] = input[j];
                }
            }

            string moves = Console.ReadLine();

            bool isWon = false;

            foreach (var move in moves)
            {
                int currentRow = playerRow;
                int currentCol = playerCol;

                switch (move)
                {
                    case 'U':
                        currentRow--;
                        break;
                    case 'D':
                        currentRow++;
                        break;
                    case 'L':
                        currentCol--;
                        break;
                    case 'R':
                        currentCol++;
                        break;
                }

                if (currentRow < 0 || currentRow == rows || currentCol < 0 || currentCol == cols)
                {
                    isWon = true;
                }
                else if (matrix[currentRow, currentCol] == 'B')
                {
                    playerRow = currentRow;
                    playerCol = currentCol;
                    SpreadBunnies(matrix, bunnies);
                    break;
                }

                matrix[playerRow, playerCol] = '.';

                if (isWon)
                {
                    SpreadBunnies(matrix, bunnies);
                    break;
                }

                playerRow = currentRow;
                playerCol = currentCol;

                matrix[currentRow, currentCol] = 'P';

                SpreadBunnies(matrix, bunnies);

                if (matrix[currentRow, currentCol] == 'B')
                {
                    break;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }

        private static void SpreadBunnies(char[,] matrix, HashSet<string> bunnies)
        {
            HashSet<string> newBunnies = new HashSet<string>();

            foreach (var index in bunnies)
            {
                int[] indexValues = index.Split(",").Select(int.Parse).ToArray();
                int i = indexValues[0];
                int j = indexValues[1];

                if (i - 1 >= 0)
                {
                    matrix[i - 1, j] = 'B'; //U
                    newBunnies.Add($"{i - 1},{j}");
                }
                if (j - 1 >= 0)
                {
                    matrix[i, j - 1] = 'B'; //L
                    newBunnies.Add($"{i},{j - 1}");

                }
                if (i + 1 < matrix.GetLength(0))
                {
                    matrix[i + 1, j] = 'B'; //D
                    newBunnies.Add($"{i + 1},{j }");

                }
                if (j + 1 < matrix.GetLength(1))
                {
                    matrix[i, j + 1] = 'B'; //R
                    newBunnies.Add($"{i},{j + 1}");
                }
            }

            bunnies.UnionWith(newBunnies);
        }
    }
}
