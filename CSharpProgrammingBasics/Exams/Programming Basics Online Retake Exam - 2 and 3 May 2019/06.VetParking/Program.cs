using System;

namespace _06.VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double tax = 0;

            for (int i = 1; i <= days; i++)
            {
                double currentTax = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 1)
                        {
                            currentTax += 2.50;
                            continue;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            currentTax += 1.25;
                            continue;
                        }
                    }
                    currentTax++;
                }

                Console.WriteLine($"Day: {i} - {currentTax:f2} leva");
                tax += currentTax;
            }

            Console.WriteLine($"Total: {tax:f2} leva");
        }
    }
}
