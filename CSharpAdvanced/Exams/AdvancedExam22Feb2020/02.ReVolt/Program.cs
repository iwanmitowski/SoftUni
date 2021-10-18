using System;
using System.Runtime.CompilerServices;

namespace _02.ReVolt
{
    class Program
    {
        public static int lastBlock;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            lastBlock = n - 1;
            int commands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < n; i++)
            {
                var currentRow = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];

                    if (matrix[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            bool isWon = false;

            for (int i = 0; i < commands; i++)
            {
                string move = Console.ReadLine();

                int currentRow = playerRow;
                int currentCol = playerCol;


                MovePlayerForward(ref currentRow, ref currentCol, move);
                IfOutsideTeleportPlayer(ref currentRow, ref currentCol);

                if (matrix[currentRow, currentCol] == 'B')
                {
                    MovePlayerForward(ref currentRow, ref currentCol, move);
                }
                else if (matrix[currentRow,currentCol] == 'T')
                {
                    MovePlayerBackward(ref currentRow, ref currentCol, move);
                }

                if (matrix[currentRow,currentCol] == 'F')
                {
                    isWon = true;
                }


                matrix[playerRow, playerCol] = '-';
                playerRow = currentRow;
                playerCol = currentCol;
                matrix[playerRow, playerCol] = 'f';

                if (isWon)
                {
                    break;
                }
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void MovePlayerForward(ref int currentRow, ref int currentCol, string move)
        {
            switch (move)
            {
                case "up":
                    currentRow--;
                    break;
                case "down":
                    currentRow++;
                    break;
                case "left":
                    currentCol--;
                    break;
                case "right":
                    currentCol++;
                    break;
            }

            IfOutsideTeleportPlayer(ref currentRow, ref currentCol);
        }

        private static void MovePlayerBackward(ref int currentRow, ref int currentCol, string move)
        {
            //BACKWARDS!!! NOT THE RIGHT PLACE TO COPY PASTA
            switch (move)
            {
                case "up":
                    currentRow++;
                    break;
                case "down":
                    currentRow--;
                    break;
                case "left":
                    currentCol++;
                    break;
                case "right":
                    currentCol--;
                    break;
            }

            IfOutsideTeleportPlayer(ref currentRow, ref currentCol);
        }

        private static void IfOutsideTeleportPlayer(ref int currentRow, ref int currentCol)
        {
            if (currentRow < 0)
            {
                currentRow = lastBlock;
            }
            else if (currentRow > lastBlock)
            {
                currentRow = 0;
            }

            if (currentCol < 0)
            {
                currentCol = lastBlock;
            }
            else if (currentCol > lastBlock)
            {
                currentCol = 0;
            }
        }
    }
}
