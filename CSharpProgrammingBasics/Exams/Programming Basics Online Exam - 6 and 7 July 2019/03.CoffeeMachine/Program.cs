using System;

namespace _03.CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string drinkType = Console.ReadLine();
            string sugar = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double drinkPrice = 0;

            int discount = 0;
           
            switch (drinkType)
            {
                case "Espresso":
                    switch (sugar)
                    {
                        case "Without":
                            drinkPrice = 0.9;
                            break;
                        case "Normal":
                            drinkPrice = 1;
                            break;
                        case "Extra":
                            drinkPrice = 1.2;
                            break;
                    }
                    
                    break;
                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without":
                            drinkPrice = 1;
                            break;
                        case "Normal":
                            drinkPrice = 1.2;
                            break;
                        case "Extra":
                            drinkPrice = 1.6;
                            break;
                    }
                    break;
                case "Tea":
                    switch (sugar)
                    {
                        case "Without":
                            drinkPrice = 0.5;
                            break;
                        case "Normal":
                            drinkPrice = 0.6;
                            break;
                        case "Extra":
                            drinkPrice = 0.7;
                            break;
                    }
                    break;
                default:
                    break;
            }

            double totalSum = drinkPrice * count;
            

            if (sugar == "Without")
            {
                totalSum*=0.65;
            }
            if (drinkType=="Espresso" && count>=5)
            {
                totalSum *= 0.75;
            }
            if (totalSum>15)
            {
                totalSum *= 0.8;
            }

            Console.WriteLine($"You bought {count} cups of {drinkType} for {totalSum:f2} lv.");
        }
    }
}
