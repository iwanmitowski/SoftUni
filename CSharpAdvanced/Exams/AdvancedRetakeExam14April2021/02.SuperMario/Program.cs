using System;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            string firstRow = Console.ReadLine();

            char[,] matrix = new char[rows, firstRow.Length];

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < firstRow.Length; j++)
                {
                    matrix[i, j] = firstRow[j];

                    if (matrix[i, j] == 'M')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }

                if (i != rows - 1)
                {
                    firstRow = Console.ReadLine();
                }
            }
            
            bool isWin = false;

            while (lives > 0)
            {
                string[] tokens = Console.ReadLine().Split();

                string move = tokens[0];

                int bowserRow = int.Parse(tokens[1]);
                int bowserCol = int.Parse(tokens[2]);

                matrix[bowserRow, bowserCol] = 'B';

                matrix[playerRow, playerCol] = '-';

                int currentRow = playerRow;
                int currentCol = playerCol;

                switch (move)
                {
                    case "W":
                        currentRow--;
                        break;
                    case "S":
                        currentRow++;
                        break;
                    case "A":
                        currentCol--;
                        break;
                    case "D":
                        currentCol++;
                        break;
                }

                lives--;

                if (currentRow < 0 || currentRow == matrix.GetLength(0) || currentCol < 0 || currentCol == matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[currentRow, currentCol] == 'B')
                {
                    lives -= 2;
                }
                else if (matrix[currentRow, currentCol] == 'P')
                {
                    isWin = true;
                    matrix[currentRow, currentCol] = '-';
                    break;
                }

                playerRow = currentRow;
                playerCol = currentCol;

                if (lives <= 0)
                {
                    break;
                }
            }

            if (isWin)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                matrix[playerRow, playerCol] = 'X';
                Console.WriteLine($"Mario died at {playerRow};{playerCol}.");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
