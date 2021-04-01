using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentCoin = Math.Round(double.Parse(Console.ReadLine()),2);
            int coinConverted = (int)(currentCoin * 100);
            int coins = 0;

            while (coinConverted > 0)
            {
                if (coinConverted - 200>=0)
                {
                    coinConverted -= 200;
                }
                else if (coinConverted - 100 >= 0)
                {
                    coinConverted -= 100;
                }
                else if (coinConverted - 50 >= 0)
                {
                    coinConverted -= 50;
                }
                else if (coinConverted - 20 >= 0)
                {
                    coinConverted -= 20;
                }
                else if (coinConverted - 10 >= 0)
                {
                    coinConverted -= 10;
                }
                else if (coinConverted -5 >= 0)
                {
                    coinConverted -=5;
                }
                else if (coinConverted - 2 >= 0)
                {
                    coinConverted -= 2;
                }
                else if (coinConverted -1 >= 0)
                {
                    coinConverted -=1;
                }
                

                coins++;
            }

            Console.WriteLine(coins);
        }
    }
}
