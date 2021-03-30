using System;

namespace _07.FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            double totalFans = double.Parse(Console.ReadLine());

            double sectA = 0;
            double sectB = 0;
            double sectV = 0;
            double sectG = 0;
                        
            for (int i = 0; i < totalFans; i++)
            {
                string sector = Console.ReadLine();

                switch (sector)
                {
                    case "A":
                        sectA++;
                        break;
                    case "B":
                        sectB++;
                        break;
                    case "V":
                        sectV++;
                        break;
                    case "G":
                        sectG++;
                        break;

                }
            }

            Console.WriteLine($"{sectA/totalFans*100:f2}%");
            Console.WriteLine($"{sectB/totalFans*100:f2}%");
            Console.WriteLine($"{sectV/totalFans*100:f2}%");
            Console.WriteLine($"{sectG/totalFans*100:f2}%");
            Console.WriteLine($"{totalFans/capacity*100:f2}%");
        }
    }
}
