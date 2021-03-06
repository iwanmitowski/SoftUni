using System;

namespace _05.BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double cakePrice = rent * 0.2;
            double drinksPrice = cakePrice - cakePrice * 0.45;
            double animator = rent / 3;

            double sum = rent + cakePrice + drinksPrice + animator;

            Console.WriteLine(sum);
        }
    }
}
