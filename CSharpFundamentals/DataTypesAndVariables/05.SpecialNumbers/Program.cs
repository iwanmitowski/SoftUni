using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int currentSum = 0;
                int currentNum = i;

                while (currentNum > 0)
                {
                    int currDigit = currentNum % 10;
                    currentSum += currDigit;
                    currentNum /= 10;
                }

                string result = currentSum == 5 || currentSum == 7 || currentSum == 11 ?
                    $"{i} -> True" :
                    $"{i} -> False";

                Console.WriteLine(result);
            }
        }
    }
}
