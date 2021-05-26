using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int currentWater = int.Parse(Console.ReadLine());

                if (currentWater+sum>255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += currentWater;
                }

            }
            Console.WriteLine(sum);
        }
    }
}
