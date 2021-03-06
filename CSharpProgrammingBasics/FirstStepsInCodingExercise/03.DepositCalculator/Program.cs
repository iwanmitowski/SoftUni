using System;

namespace _03.DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double interest = deposit * percent/100;
            double interestPerMonth = interest / 12;

            
            double sum = deposit + (time * ((deposit * percent/100) / 12));

            Console.WriteLine(sum);
        }
    }
}
