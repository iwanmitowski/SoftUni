using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int firstPillarRow = -1;
            int firstPillarCol = -1;

            int secondPillarRow = -1;
            int secondPillarCol = -1;

            int startRow = -1;
            int startCol = -1;


            for (int i = 0; i < n; i++)
            {
                var currentRow = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];

                    if (matrix[i, j] == 'O')
                    {
                        if (firstPillarRow == -1)
                        {
                            firstPillarRow = i;
                            firstPillarCol = j;
                        }
                        else
                        {
                            secondPillarRow = i;
                            secondPillarCol = j;
                        }
                    }
                    else if (matrix[i, j] == 'S')
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            int currentMoney = 0;

            while (currentMoney < 50)
            {
                string move = Console.ReadLine();

                int currentRow = startRow;
                int currentCol = startCol;
                matrix[startRow, startCol] = '-';

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

                if (currentRow < 0 || currentRow == n ||
                    currentCol < 0 || currentCol == n)
                {
                    break;
                }

                if (char.IsDigit(matrix[currentRow, currentCol]))
                {
                    currentMoney += matrix[currentRow, currentCol] - '0';
                }
                else if (matrix[currentRow, currentCol] == 'O')
                {

                    matrix[currentRow, currentCol] = '-';

                    if (currentRow == firstPillarRow && currentCol == firstPillarCol)
                    {
                        currentRow = secondPillarRow;
                        currentCol = secondPillarCol;
                    }
                    else
                    {
                        currentRow = firstPillarRow;
                        currentCol = firstPillarCol;
                    }

                }


                startRow = currentRow;
                startCol = currentCol;

                matrix[currentRow, currentCol] = 'S';
            }

            if (currentMoney < 50)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {currentMoney}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
