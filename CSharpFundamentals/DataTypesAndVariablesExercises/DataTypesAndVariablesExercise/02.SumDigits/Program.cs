using System;

namespace _02.SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int currentNumber = int.Parse(Console.ReadLine());

            while (currentNumber>0)
            {
                int currentDigit = currentNumber % 10;
                sum += currentDigit;
                currentNumber /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}
