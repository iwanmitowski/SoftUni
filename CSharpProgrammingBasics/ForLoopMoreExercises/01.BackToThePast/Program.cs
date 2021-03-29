using System;
using System.Linq;

namespace _01.BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            int years = 18;

            int neededMoney = 0;

            for (int i = 1800; i <= year; i++)
            {
                

                if (i%2==0)
                {
                    money -= 12000;
                }
                else
                {
                    double paying = 12000 + (50 * years);
                    money -= paying;
                }
                years++;
            }

            if (neededMoney<=money)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {money:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(money):f2} dollars to survive.");
            }
            
        }
    }
}
