using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            string biggestModel = string.Empty;
            double biggestSize = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double currentSize = Math.PI * (radius*radius) * height;

                if (currentSize>biggestSize)
                {
                    biggestModel = model;
                    biggestSize = currentSize;
                }

            }

            Console.WriteLine(biggestModel);
        }
    }
}
