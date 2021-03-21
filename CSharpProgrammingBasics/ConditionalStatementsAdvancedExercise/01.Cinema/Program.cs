using System;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketType = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int totalSpace = r * c;

            int premiere = 12;
            double normal = 7.5;
            int discount = 5;

            double totalPrice = totalSpace;

            switch (ticketType)
            {
                case "Premiere":
                    totalPrice *= premiere;
                    break;
                case "Normal":
                    totalPrice *= normal;
                    break;
                case "Discount":
                    totalPrice *= discount;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{totalPrice:f2} leva");
        }
    }
}
