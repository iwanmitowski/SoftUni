using System;

namespace _04.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentPoints = 301;
            string name = Console.ReadLine();

            string field = Console.ReadLine();
            int shots = 0;
            int failed = 0;
            while (field != "Retire")
            {
                int points = int.Parse(Console.ReadLine());

                int currentHit = 0;
               

                switch (field)
                {
                    case "Single":
                        currentHit= points;
                        break;
                    case "Double":
                        currentHit = 2 * points;
                        break;
                    case "Triple":
                        currentHit = 3 * points;
                        break;
                }

                if (currentHit > currentPoints)
                {
                    failed++;

                    field = Console.ReadLine();
                    
                    continue;
                }

                currentPoints -= currentHit;
                shots++;

                if (currentPoints==0)
                {
                    Console.WriteLine($"{name} won the leg with {shots} shots.");
                    Environment.Exit(0);
                }

                field = Console.ReadLine();
            }

            Console.WriteLine($"{name} retired after {failed} unsuccessful shots.");
        }
    }
}
