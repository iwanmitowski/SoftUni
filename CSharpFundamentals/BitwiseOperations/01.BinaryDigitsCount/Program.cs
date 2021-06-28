using System;
using System.Linq;

namespace _01.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int binary = int.Parse(Console.ReadLine());
            int digit = int.Parse(Console.ReadLine());

            int counter = 0;

            while (binary>0)
            {
                int lastDigit = binary & 1;

                if (lastDigit == digit)
                {
                    counter++;
                }

                binary = binary >> 1;
            }

            Console.WriteLine(counter);
        }
    }
}
