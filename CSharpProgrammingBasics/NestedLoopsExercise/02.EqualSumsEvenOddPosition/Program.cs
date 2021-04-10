using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                int evenSum = 0;
                int oddSum = 0;

                for (int j = 0; j < 6; j++)
                {
                    if (j % 2 == 0)
                    {
                        evenSum += i.ToString()[j];
                    }
                    else
                    {
                        oddSum += i.ToString()[j];
                    }
                }
                if (evenSum==oddSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
