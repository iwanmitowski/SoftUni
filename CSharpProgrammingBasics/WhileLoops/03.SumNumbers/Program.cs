using System;

namespace _03.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());

            int currentSum = int.Parse(Console.ReadLine());
          

            while (currentSum<sum)
            {
                int number = int.Parse(Console.ReadLine());
                currentSum += number;
                
            }

            Console.WriteLine(currentSum);
        }
    }
}
