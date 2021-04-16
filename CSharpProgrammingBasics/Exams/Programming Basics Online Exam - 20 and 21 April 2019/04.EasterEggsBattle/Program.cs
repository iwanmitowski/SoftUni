using System;

namespace _04.EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "End of battle")
            {
                if (input == "one")
                {
                    p2--;
                }
                else
                {
                    p1--;
                }

                if (p1 == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {p2} eggs left.");
                    Environment.Exit(0);
                }
                else if (p2 == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {p1} eggs left.");
                    Environment.Exit(0);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Player one has {p1} eggs left.");
            Console.WriteLine($"Player two has {p2} eggs left.");
        }
    }
}
