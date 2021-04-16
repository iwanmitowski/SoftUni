using System;

namespace _03.PaintingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string color = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            int price = 0;

            switch (color)
            {
                case "Red":
                    switch (size)
                    {
                        case "Large":
                            price = 16;
                            break;
                        case "Medium":
                            price = 13;
                            break;
                        case "Small":
                            price = 9;
                            break;
                    }
                    break;
                case "Green":
                    switch (size)
                    {
                        case "Large":
                            price = 12;
                            break;
                        case "Medium":
                            price = 9;
                            break;
                        case "Small":
                            price = 8;
                            break;
                    }
                    break;
                case "Yellow":
                    switch (size)
                    {
                        case "Large":
                            price = 9;
                            break;
                        case "Medium":
                            price = 7;
                            break;
                        case "Small":
                            price = 5;
                            break;
                    }
                    break;
            }

            double totalPrice = price * count;
            totalPrice *= 0.65;

            Console.WriteLine($"{totalPrice:f2} leva.");
        }
    }
}
