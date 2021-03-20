using System;

namespace _05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double productPrice = 0;


            string drink = Console.ReadLine();
            string town = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            switch (town)
            {
                case "Sofia":
                    switch (drink)
                    {
                        case "coffee":
                            productPrice = 0.5;
                            break;
                        case "water":
                            productPrice = 0.8;
                            break;
                        case "beer":
                            productPrice = 1.2;
                            break;
                        case "sweets":
                            productPrice = 1.45;
                            break;
                        case "peanuts":
                            productPrice = 1.6;
                            break;
                        default:
                            break;
                    }
                    break;


                case "Plovdiv":
                    switch (drink)
                    {
                        case "coffee":
                            productPrice = 0.4;
                            break;
                        case "water":
                            productPrice = 0.7;
                            break;
                        case "beer":
                            productPrice = 1.15;
                            break;
                        case "sweets":
                            productPrice = 1.3;
                            break;
                        case "peanuts":
                            productPrice = 1.5;
                            break;
                        default:
                            break;
                    }
                    break;


                case "Varna":
                    switch (drink)
                    {
                        case "coffee":
                            productPrice = 0.45;
                            break;
                        case "water":
                            productPrice = 0.7;
                            break;
                        case "beer":
                            productPrice = 1.1;
                            break;
                        case "sweets":
                            productPrice = 1.35;
                            break;
                        case "peanuts":
                            productPrice = 1.55;
                            break;
                        default:
                            break;
                    }
                    break;
                   
                default:
                    break;

            }
            Console.WriteLine(productPrice * quantity);

        }
    }
}
