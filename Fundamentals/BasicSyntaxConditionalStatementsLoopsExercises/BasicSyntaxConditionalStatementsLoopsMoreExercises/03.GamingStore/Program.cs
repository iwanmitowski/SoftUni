using System;

namespace _03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double totalSpent = money;

            string input = Console.ReadLine();

            while (input!="Game Time")
            {
                double gamePrice = 0;

                switch (input)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    default:

                        Console.WriteLine("Not Found");
                        input = Console.ReadLine();

                        continue;
                }
                if (gamePrice>money)
                {
                    Console.WriteLine("Too Expensive");
                }
                else 
                {
                    money -= gamePrice;

                    Console.WriteLine($"Bought {input}");

                    if (money==0)
                    {
                        Console.WriteLine("Out of money!");
                        Environment.Exit(0);
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${totalSpent-money:f2}. Remaining: ${money:f2}");
        }
    }
}
