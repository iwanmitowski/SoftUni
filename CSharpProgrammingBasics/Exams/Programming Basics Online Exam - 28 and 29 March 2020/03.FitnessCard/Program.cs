using System;

namespace _03.FitnessCard
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sportType = Console.ReadLine();

            double cardPrice = 0;

            switch (sportType)
            {
                case "Gym":
                    if (gender=="m")
                    {
                        cardPrice = 42;
                    }
                    else
                    {
                        cardPrice = 35;
                    }
                    break;
                case "Boxing":
                    if (gender == "m")
                    {
                        cardPrice = 41;
                    }
                    else
                    {
                        cardPrice = 37;
                    }
                    break;
                case "Yoga":
                    if (gender == "m")
                    {
                        cardPrice = 45;
                    }
                    else
                    {
                        cardPrice = 42;
                    }
                    break;
                case "Zumba":
                    if (gender == "m")
                    {
                        cardPrice = 34;
                    }
                    else
                    {
                        cardPrice = 31;
                    }
                    break;
                case "Dances":
                    if (gender == "m")
                    {
                        cardPrice = 51;
                    }
                    else
                    {
                        cardPrice = 53;
                    }
                    break;
                case "Pilates":
                    if (gender == "m")
                    {
                        cardPrice = 39;
                    }
                    else
                    {
                        cardPrice = 37;
                    }
                    break;
                default:
                    break;
            }

            if (age<=19)
            {
                cardPrice *= 0.8;
            }

            if (money >= cardPrice)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sportType}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${cardPrice-money:f2} more.");
            }
        }
    }
}
