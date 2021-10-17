using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[][] field = new string[n][];

            for (int i = 0; i < n; i++)
            {
                field[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            int myTokens = 0;
            int oponentTokens = 0;

            string input = Console.ReadLine();

            while (input != "Gong")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string turn = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (turn == "Find")
                {
                    if (AreValid(row, col, field) && field[row][col] == "T")
                    {
                        myTokens++;
                        field[row][col] = "-";
                    }
                }
                else
                {
                    string oponentMove = tokens[3];
                    bool areValid;

                    for (int i = 0; i < 4; i++)
                    {
                        try
                        {
                            areValid = AreValid(row, col, field);
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                        if (areValid && field[row][col] == "T")
                        {
                            oponentTokens++;
                            field[row][col] = "-";
                        }
                        else if (!areValid && i == 0)
                        {
                            break;
                        }

                        switch (oponentMove)
                        {
                            case "up":
                                row--;
                                break;
                            case "down":
                                row++;
                                break;
                            case "left":
                                col--;
                                break;
                            case "right":
                                col++;
                                break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var line in field)
            {
                Console.WriteLine(string.Join(" ", line));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");
        }
        public static bool AreValid(int row, int col, string[][] field)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field[row].Length;
        }
    }
}
