using System;

namespace _04.GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();

            int p1 = 0;
            int p2 = 0;

            string input = Console.ReadLine();

            while (input != "End of game")
            {
                int firstCard = int.Parse(input);
                int secondCard = int.Parse(Console.ReadLine());

                if (firstCard > secondCard)
                {
                    p1 += firstCard - secondCard;
                }
                else if (secondCard > firstCard)
                {
                    p2 += secondCard - firstCard;
                }
                else
                {
                    firstCard = int.Parse(Console.ReadLine());
                    secondCard = int.Parse(Console.ReadLine());

                    Console.WriteLine("Number wars!");

                    if (firstCard > secondCard)
                    {
                        Console.WriteLine($"{firstName} is winner with {p1} points");

                    }
                    else if (secondCard > firstCard)
                    {
                        Console.WriteLine($"{secondName} is winner with {p2} points");
                    }
                                        
                    Environment.Exit(0);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{firstName} has {p1} points");
            Console.WriteLine($"{secondName} has {p2} points");

        }
    }
}
