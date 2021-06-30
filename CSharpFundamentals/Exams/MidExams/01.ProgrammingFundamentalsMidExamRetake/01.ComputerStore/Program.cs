using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double total = 0;

            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);

                if (price > 0)
                {
                    total += price;
                }
                else
                {
                    Console.WriteLine("Invalid price!");
                }

                input = Console.ReadLine();
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {


                double taxes = total * 0.2;
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {total:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                total += taxes;

                if (input == "special")
                {
                    total *= 0.9;   
                }

                Console.WriteLine($"Total price: {total:f2}$");
            }

        }
    }
}
