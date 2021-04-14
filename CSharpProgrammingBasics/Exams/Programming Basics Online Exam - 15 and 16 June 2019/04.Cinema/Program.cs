using System;

namespace _04.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            int guests = 0;
            int ticketPrice = 5;

            int finalPrice = 0;

            string input = Console.ReadLine();

            while (input!="Movie time!")
            {
                int count = int.Parse(input);

                if (count+guests>capacity)
                {
                    Console.WriteLine("The cinema is full.");
                    Console.WriteLine($"Cinema income - {finalPrice} lv.");

                    Environment.Exit(0);
                }

                finalPrice += ticketPrice * count;
                guests += count;

                if (count%3==0)
                {
                    finalPrice -= ticketPrice;
                }

                

                input = Console.ReadLine();
            }

            Console.WriteLine($"There are {capacity-guests} seats left in the cinema.");
            Console.WriteLine($"Cinema income - {finalPrice} lv.");
        }
    }
}
