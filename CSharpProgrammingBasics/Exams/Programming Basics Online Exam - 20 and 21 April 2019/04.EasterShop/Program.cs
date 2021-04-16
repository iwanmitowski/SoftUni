using System;

namespace _04.EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            int sold = 0;

            string input = Console.ReadLine();

            while (input!="Close")
            {
                int count = int.Parse(Console.ReadLine());

                if (input=="Buy")
                {
                    if (count>eggs)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggs}.");
                        Environment.Exit(0);
                    }
                    eggs -= count;
                    sold += count;

                }
                else
                {
                    eggs += count;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Store is closed!");
            Console.WriteLine($"{sold} eggs sold.");
        }
    }
}
