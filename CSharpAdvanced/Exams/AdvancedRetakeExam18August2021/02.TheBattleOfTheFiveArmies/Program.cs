using System;

namespace _02.TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            var row = Console.ReadLine();

            char[,] matrix = new char[rows, row.Length];

            int armyRow = -1;
            int armyCol = -1;

            for (int j = 0; j < row.Length; j++)
            {
                matrix[0, j] = row[j];

                if (matrix[0, j] == 'A')
                {
                    armyRow = 0;
                    armyCol = j;
                }
            }

            for (int i = 1; i < rows; i++)
            {
                row = Console.ReadLine();

                for (int j = 0; j < row.Length; j++)
                {
                    matrix[i, j] = row[j];

                    if (matrix[i, j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                    }
                }
            }

            bool isWin = false;

            while (armor > 0)
            {
                var input = Console.ReadLine().Split();

                string move = input[0];

                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                matrix[spawnRow, spawnCol] = 'O';

                int currentRow = armyRow;
                int currentCol = armyCol;

                matrix[currentRow, currentCol] = '-';

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

                armor--;

                if (currentRow < 0 || currentRow == matrix.GetLength(0) || currentCol < 0 || currentCol == matrix.GetLength(1))
                {
                    continue;
                }

                if (matrix[currentRow, currentCol] == 'O')
                {
                    armor -= 2;
                }

                if (matrix[currentRow, currentCol] == 'M')
                {
                    isWin = true;
                    armyRow = currentRow;
                    armyCol = currentCol;
                    matrix[currentRow, currentCol] = '-';
                    break;
                }

                if (armor <= 0)
                {
                    matrix[currentRow, currentCol] = 'X';
                    armyRow = currentRow;
                    armyCol = currentCol;
                    break;
                }

                matrix[currentRow, currentCol] = 'A';
                armyRow = currentRow;
                armyCol = currentCol;
            }

            if (isWin)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }
            else 
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
