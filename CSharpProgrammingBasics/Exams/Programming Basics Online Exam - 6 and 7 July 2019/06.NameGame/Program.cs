using System;

namespace _06.NameGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            string winnerName = string.Empty;
            int maxScore = int.MinValue;

            while (name != "Stop")
            {
                int currentScore = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    char currentChar = (char)(int.Parse(Console.ReadLine()));

                    if (name[i] == currentChar)
                    {
                        currentScore += 10;
                    }
                    else
                    {
                        currentScore += 2;
                    }

                    

                }

                if (currentScore >= maxScore)
                {
                    winnerName = name;
                    maxScore = currentScore;
                }
                name = Console.ReadLine();
            }

            Console.WriteLine($"The winner is {winnerName} with {maxScore} points!");
        }
    }
}
