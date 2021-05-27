using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;

            string coin = Console.ReadLine();

            while (coin != "Start")
            {
                double currentCoin = double.Parse(coin);

                if (currentCoin == 0.1
                    || currentCoin == 0.2
                    || currentCoin == 0.5
                    || currentCoin == 1
                    || currentCoin == 2
                    )
                {
                    sum += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }

                coin = Console.ReadLine();
            }

            string productInput = Console.ReadLine();
            int nutsPrice = 2;
            double waterPrice = 0.7;
            double crispsPrice = 1.5;
            double sodaPrice = 0.8;
            int cokePrice = 1;


            while (productInput != "End")
            {
                string product = string.Empty;

                switch (productInput)
                {
                    case "Nuts":
                        if (sum>=nutsPrice)
                        {
                            sum -= nutsPrice;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, not enough money");
                            productInput = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Water":
                        if (sum >= waterPrice)
                        {
                            sum -= waterPrice;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, not enough money");
                            productInput = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Crisps":
                        if (sum >= crispsPrice)
                        {
                            sum -= crispsPrice;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, not enough money");
                            productInput = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Soda":
                        if (sum >= sodaPrice)
                        {
                            sum -= sodaPrice;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, not enough money");
                            productInput = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Coke":
                        if (sum >= cokePrice)
                        {
                            sum -= cokePrice;
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, not enough money");
                            productInput = Console.ReadLine();
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        productInput = Console.ReadLine();
                        continue;
                }

                Console.WriteLine($"Purchased {productInput.ToLower()}");
                productInput = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
