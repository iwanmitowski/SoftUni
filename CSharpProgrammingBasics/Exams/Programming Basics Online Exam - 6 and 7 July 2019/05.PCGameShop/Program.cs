using System;

namespace _05.PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double hearthstone = 0;
            double overwatch = 0;
            double fortnite = 0;
            double others = 0;

            for (int i = 0; i < n; i++)
            {
                string game = Console.ReadLine();

                switch (game)
                {
                    case "Hearthstone":
                        hearthstone++;
                        break;
                    case "Fornite":
                        fortnite++;
                        break;
                    case "Overwatch":
                        overwatch++;
                        break;
                    default:
                        others++;
                        break;
                }
            }

            Console.WriteLine($"Hearthstone - {hearthstone/n*100:f2}%");
            Console.WriteLine($"Fornite - {fortnite/n*100:f2}%");
            Console.WriteLine($"Overwatch - {overwatch/n*100:f2}%");
            Console.WriteLine($"Others - {others/n*100:f2}%");
        }
    }
}
