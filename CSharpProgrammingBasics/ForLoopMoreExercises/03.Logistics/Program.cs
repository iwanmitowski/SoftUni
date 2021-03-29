using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargoCount = int.Parse(Console.ReadLine());

            double bus = 0;
            double truck = 0;
            double train = 0;

            double totalCargo = 0;
            int countingWeight = 0;

            for (int i = 0; i < cargoCount; i++)
            {
                int currentCargo = int.Parse(Console.ReadLine());

                countingWeight += currentCargo;

                if (currentCargo <= 3)
                {
                    bus += currentCargo;
                    totalCargo += currentCargo*200;

                }
                else if (currentCargo > 3 && currentCargo <= 11)
                {
                    truck += currentCargo;
                    totalCargo += currentCargo * 175;

                }
                else
                {
                    train += currentCargo;
                    totalCargo += currentCargo * 120;

                }
            }

            Console.WriteLine($"{totalCargo/ countingWeight:f2}");
            Console.WriteLine($"{bus/ countingWeight * 100:f2}%");
            Console.WriteLine($"{truck/ countingWeight * 100:f2}%");
            Console.WriteLine($"{train/ countingWeight * 100:f2}%");

        }
    }
}
