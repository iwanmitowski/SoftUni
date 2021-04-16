using System;

namespace _06.EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());

            double totalPurchase = 0;

            bool discount = false;

            for (int i = 0; i < clients; i++)
            {
                string decoration = Console.ReadLine();
                double currentPurchase = 0;
                int counter = 0;

                while (decoration!="Finish")
                {
                    switch (decoration)
                    {
                        case "basket":
                            currentPurchase += 1.5;
                            break;
                        case "wreath":
                            currentPurchase += 3.8;
                            break;
                        case "chocolate bunny":
                            currentPurchase += 7;
                            break;
                    }

                    counter++;
                    
                    decoration = Console.ReadLine();
                }

                if (counter%2==0)
                {
                    currentPurchase *= 0.8;
                }

                Console.WriteLine($"You purchased {counter} items for {currentPurchase:f2} leva.");
                totalPurchase += currentPurchase;

            }

            Console.WriteLine($"Average bill per client is: {totalPurchase/clients:f2} leva.");
        }
    }
}
