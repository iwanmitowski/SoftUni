using System;

namespace _01.Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int wins = 0;

            while (input != "End of battle")
            {
                int distance = int.Parse(input);

                if (energy>=distance)
                {
                    energy -= distance;
                    wins++;

                    if (wins%3==0)
                    {
                        energy += wins;
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    Environment.Exit(0);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
        }
    }
}
