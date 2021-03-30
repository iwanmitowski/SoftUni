using System;

namespace _09.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 23; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    Console.WriteLine($"{i} : {j}");
                }
            }
        }
    }
}
