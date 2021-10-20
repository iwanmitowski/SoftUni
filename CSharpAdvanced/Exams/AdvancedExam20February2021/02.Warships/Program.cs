using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace _02.Warships
{
    class Program
    {
        static int fieldSize;
        static string[,] field;
        static int shipsP1;
        static int shipsP2;
        static void Main(string[] args)
        {
            fieldSize = int.Parse(Console.ReadLine());

            field = new string[fieldSize, fieldSize];

            Queue<string> coordinates = new Queue<string>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < fieldSize; i++)
            {
                string[] currentRow = Console.ReadLine().Split();

                for (int j = 0; j < fieldSize; j++)
                {
                    field[i, j] = currentRow[j];

                    if (field[i, j] == "<")
                    {
                        shipsP1++;
                    }
                    else if (field[i, j] == ">")
                    {
                        shipsP2++;
                    }
                }
            }

            int totalShips = shipsP1 + shipsP2;

            while (shipsP1 > 0 && shipsP2 > 0 && coordinates.Any())
            {
                var currentCoordinates = coordinates.Dequeue().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int currentRow = currentCoordinates[0];
                int currentCol = currentCoordinates[1];

                if (AreInvalidCoordinates(currentRow, currentCol))
                {
                    continue;
                }

                ReducePlayerShipsIfHit(currentRow, currentCol);

                if (field[currentRow, currentCol] == "#")
                {
                    for (int i = currentRow - 1; i < currentRow + 2; i++)
                    {
                        for (int j = currentCol - 1; j < currentCol + 2; j++)
                        {
                            if (AreInvalidCoordinates(i, j))
                            {
                                continue;
                            }

                            ReducePlayerShipsIfHit(i, j);
                        }
                    }
                }
            }

            int destroyedShips = totalShips - (shipsP1 + shipsP2);

            if (shipsP1 > 0 && shipsP2 == 0)
            {
                Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else if (shipsP2 > 0 && shipsP1 == 0)
            {
                Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsP1} ships left. Player Two has {shipsP2} ships left.");
            }

        }

        private static void ReducePlayerShipsIfHit(int currentRow, int currentCol)
        {
            if (field[currentRow, currentCol] == "<")
            {
                shipsP1--;
                field[currentRow, currentCol] = "X";
            }
            else if (field[currentRow, currentCol] == ">")
            {
                shipsP2--;
                field[currentRow, currentCol] = "X";
            }
        }

        private static bool AreInvalidCoordinates(int currentRow, int currentCol)
        {
            return currentRow < 0 || currentRow >= fieldSize ||
                   currentCol < 0 || currentCol >= fieldSize;
        }
    }
}
