using System;
using System.Runtime.InteropServices;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double totalPrice = Calc(drink, count);

            Console.WriteLine($"{totalPrice:f2}");
        }

        private static double Calc(string drink, int count)
        {
            double result = 0;

            switch (drink)
            {
                case "coffee":
                    result = 1.5;
                    break;
                case "water":
                    result = 1;
                    break;
                case "coke":
                    result = 1.4;
                    break;
                case "snacks":
                    result = 2;
                    break;
            }

            return result * count;
        }
    }
}
