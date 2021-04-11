using System;

namespace _03.EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string gelSize = Console.ReadLine();
            int sets = int.Parse(Console.ReadLine());

            int count = 0;
            double pricePerCount = 0;

            switch (gelSize)
            {
                case "small":
                    count = 2;
                    break;
                case "big":
                    count = 5;
                    break;
            }

            switch (fruit)
            {
                case "Watermelon":
                    if (count==2)
                    {
                        pricePerCount = 56;
                    }
                    else
                    {
                        pricePerCount = 28.70;
                    }
                    break;
                case "Mango":
                    if (count == 2)
                    {
                        pricePerCount = 36.66;
                    }
                    else
                    {
                        pricePerCount = 19.60;
                    }
                    break;
                case "Pineapple":
                    if (count == 2)
                    {
                        pricePerCount = 42.10;
                    }
                    else
                    {
                        pricePerCount = 24.80;
                    }
                    break;
                case "Raspberry":
                    if (count == 2)
                    {
                        pricePerCount = 20;
                    }
                    else
                    {
                        pricePerCount = 15.20;
                    }
                    break;
                default:
                    break;
            }

            double totalPrice = count * pricePerCount * sets;

            if (totalPrice>=400&totalPrice<=1000)
            {
                totalPrice *= 0.85;
            }
            else if (totalPrice>1000)
            {
                totalPrice /= 2;
            }

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
