using System;

namespace _04.Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int notToPaint = int.Parse(Console.ReadLine());

            double totalSpace = h * w * 4;
            totalSpace -= (totalSpace * notToPaint) / 100;

            string input = Console.ReadLine();

            bool isPainted = false;

            while (input != "Tired!")
            {
                int space = int.Parse(input);

                totalSpace -= space;
                if (totalSpace <= 0)
                {
                    isPainted = true;
                    break;
                }

                input = Console.ReadLine();
            }
            if (isPainted)
            {
                if (totalSpace < 0)
                {
                    Console.WriteLine($"All walls are painted and you have {Math.Abs(totalSpace)} l paint left!");
                }
                else
                {
                    Console.WriteLine("All walls are painted! Great job, Pesho!");
                }
            }
            else
            {
                Console.WriteLine($"{totalSpace} quadratic m left.");
            }
        }
    }
}
