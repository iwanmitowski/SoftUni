using System;

namespace _02.PawnWars
{
    class Program
    {
        static char[,] matrix = new char[8, 8];
        static void Main(string[] args)
        {
            int whiteRow = -1;
            int whiteCol = -1;
            int blackRow = -1;
            int blackCol = -1;

            string[,] chessBoard = new string[8, 8];

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 7; j >= 0; j--)
                {
                    chessBoard[i, j] = $"{(char)('a' + j)}{8 - i}";
                }
            }

            //Print chess board to debug:

            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Console.Write($"{chessBoard[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}

            for (int i = 0; i < 8; i++)
            {
                var row = Console.ReadLine();

                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = row[j];

                    if (matrix[i, j] == 'b')
                    {
                        blackRow = i;
                        blackCol = j;
                    }
                    else if (matrix[i, j] == 'w')
                    {
                        whiteRow = i;
                        whiteCol = j;
                    }
                }
            }
            int counter = 0;

            while (true)
            {
                if (counter % 2 == 0)
                {
                    matrix[whiteRow, whiteCol] = '-';

                    if (CanCapture(whiteRow, whiteCol, "white"))
                    {
                        Console.WriteLine($"Game over! White capture on {chessBoard[blackRow, blackCol]}.");
                        Environment.Exit(0);
                    }

                    whiteRow--;
                    matrix[whiteRow, whiteCol] = 'w';

                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessBoard[whiteRow, whiteCol]}.");

                        Environment.Exit(0);
                    }
                }
                else
                {
                    matrix[blackRow, blackCol] = '-';

                    if (CanCapture(blackRow, blackCol, "black"))
                    {
                        Console.WriteLine($"Game over! Black capture on {chessBoard[whiteRow, whiteCol]}.");
                        Environment.Exit(0);
                    }

                    blackRow++;
                    matrix[blackRow, blackCol] = 'b';

                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessBoard[blackRow, blackCol]}.");

                        Environment.Exit(0);
                    }

                }

                counter++;
            }
        }

        private static bool CanCapture(int currentRow, int currentCol, string color)
        {
            if (color == "white")
            {
                return (currentCol - 1 >= 0 && matrix[currentRow - 1, currentCol - 1] == 'b') ||
                       (currentCol + 1 < 8 && matrix[currentRow - 1, currentCol + 1] == 'b'); ;
            }

            return (currentCol + 1 < 8 && matrix[currentRow + 1, currentCol + 1] == 'w') ||
                   (currentCol - 1 >= 0 && matrix[currentRow + 1, currentCol - 1] == 'w');
        }
    }
}
