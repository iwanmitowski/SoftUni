using System;

namespace _11.CleaverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int years = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine()); 
            double toyPrice = double.Parse(Console.ReadLine());

            double money = 0;
            int toys = 0;

            for (int i = 1; i <= years; i++)
            {
                if (i%2==0)
                {
                    money += (i*10)/2;
                    money--;
                    
                }
                else
                {
                    toys++;
                }

            }

            double soldToys = toys * toyPrice;
            money += soldToys;

            if (money>=washingMachinePrice)
            {
                Console.WriteLine($"Yes! {money-washingMachinePrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice-money:f2}");
            }
        }
    }
}
