using System;

namespace _05.SuitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int count = 0;
            int successful = 0;

            while (input != "End")
            {
                double suitCase = double.Parse(input);
                count++;

                if (count % 3 == 0)
                {
                    suitCase *= 1.1;
                }

                if (suitCase <= capacity)
                {
                    capacity -= suitCase;
                    successful++;

                }
                else
                {
                    Console.WriteLine("No more space!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!"); 
            }
            
            Console.WriteLine($"Statistic: {successful} suitcases loaded.");

        }
    }
}
