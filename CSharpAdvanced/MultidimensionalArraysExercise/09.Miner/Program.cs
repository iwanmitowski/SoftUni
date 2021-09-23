using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, size];

            int totalCoals = 0;
            int playerRow = -1;
            int playerCol = -1;

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < size; i++)
            {

                string[] field = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = field[j];

                    if (matrix[i, j] == "s")
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                    else if (matrix[i, j] == "c")
                    {
                        totalCoals++;
                    }

                }
            }

            int collectedCoal = 0;
            bool isExited = false;
            bool areMined = false;

            foreach (var move in commands)
            {
                int currentRow = playerRow;
                int currentCol = playerCol;

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

                if (currentRow < 0 || currentRow == size || currentCol < 0 || currentCol == size)
                {
                    continue;
                }

                if (matrix[currentRow, currentCol] == "c")
                {
                    collectedCoal++;

                    if (totalCoals == collectedCoal)
                    {
                        areMined = true;
                    }
                }
                else if (matrix[currentRow, currentCol] == "e")
                {
                    isExited = true;
                }

                matrix[currentRow, currentCol] = "s";
                matrix[playerRow, playerCol] = "*";

                playerRow = currentRow;
                playerCol = currentCol;

                if (areMined || isExited)
                {
                    break;
                }
            }

            if (areMined)
            {
                Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");

            }
            else if (isExited)
            {
                Console.WriteLine($"Game over! ({playerRow}, {playerCol})");

            }
            else
            {
                Console.WriteLine($"{totalCoals - collectedCoal} coals left. ({playerRow}, {playerCol})");
            }

        }
    }
}
