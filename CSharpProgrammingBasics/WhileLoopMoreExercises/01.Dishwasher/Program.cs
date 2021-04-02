using System;

namespace _01.Dishwasher
{
    class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            int detregentQuantity = 750;

            int totalDetregent = bottles * detregentQuantity;
            int usedDetregent = 0;

            int plateDetregent = 5;
            int panDetregent = 15;

            int plateCount = 0;
            int panCount = 0;

            int counter = 1;

            string input = Console.ReadLine();

            while (input != "End")
            {
                int dishes = int.Parse(input);

                if (counter % 3 == 0)
                {
                    panCount += dishes;
                    totalDetregent -= dishes * panDetregent;
                }
                else
                {
                    plateCount += dishes;
                    totalDetregent -= dishes * plateDetregent;
                }

                if (totalDetregent < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(totalDetregent)} ml. more necessary!");
                    Environment.Exit(0);
                }

                counter++;

                input = Console.ReadLine();
            }

            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{plateCount} dishes and {panCount} pots were washed.");
            Console.WriteLine($"Leftover detergent {totalDetregent} ml.");


        }
    }
}
