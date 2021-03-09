using System;

namespace _01.Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbol = "*";
            int counter = 0;

            for (int i = 0; i < 100; i++)
            {
                counter++;
                Console.Write(symbol);
                if (counter==10)
                {
                    Console.WriteLine();
                    counter = 0;
                }

            }
        }
    }
}
