using System;

namespace _07.AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            double totalSum = 0;

            while (input!="NoMoreMoney")
            {
                double income = double.Parse(input);

                if (income>=0)
                {
                    Console.WriteLine($"Increase: {income:f2}");
                    totalSum += income;
                    
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {totalSum:f2}");
        }
    }
}
