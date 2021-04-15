using System;

namespace _01.BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int basketballTax = int.Parse(Console.ReadLine());
            double sneakers = basketballTax * 0.6;
            double shirt = sneakers * 0.8;
            double ball = shirt / 4;
            double accessories = ball / 5;

            double totalSum = basketballTax + sneakers + shirt + ball + accessories;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
