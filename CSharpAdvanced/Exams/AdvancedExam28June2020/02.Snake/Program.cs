using System;
using System.Numerics;

namespace _02.Snake
{
    class Program
    {
        static int n;
        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;

            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = row[j];

                    if (field[i, j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    else if (field[i, j] == 'B')
                    {
                        if (firstBurrowRow == -1)
                        {
                            firstBurrowRow = i;
                            firstBurrowCol = j;
                        }
                        else
                        {
                            secondBurrowRow = i;
                            secondBurrowCol = j;
                        }
                    }
                }
            }


            int food = 0;
            bool isFed = false;

            while (true)
            {
                string move = Console.ReadLine();

                int currentRow = snakeRow;
                int currentCol = snakeCol;

                field[snakeRow, snakeCol] = '.';

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


                if (field[currentRow, currentCol] == '*')
                {
                    food++;

                    if (food == 10)
                    {
                        isFed = true;
                        field[currentRow, currentCol] = 'S';
                        break;
                    }
                }
                else if (field[currentRow, currentCol] == 'B')
                {
                    field[currentRow, currentCol] = '.';

                    if (currentRow == firstBurrowRow && currentCol == firstBurrowCol)
                    {
                        currentRow = secondBurrowRow;
                        currentCol = secondBurrowCol;
                    }
                    else
                    {
                        currentRow = firstBurrowRow;
                        currentCol = firstBurrowCol;
                    }
                }

                field[currentRow, currentCol] = 'S';
                snakeRow = currentRow;
                snakeCol = currentCol;
            }

            if (isFed)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {food }");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i, j]);
                }

                Console.WriteLine();
            }

        }
    }
}
