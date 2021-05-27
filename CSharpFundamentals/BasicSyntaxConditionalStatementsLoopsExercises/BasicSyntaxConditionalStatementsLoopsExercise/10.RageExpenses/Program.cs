using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double expenses = 0;

            int keyboardsCounter = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i%6==0)
                {
                    expenses += headsetPrice + mousePrice + keyboardPrice;

                    keyboardsCounter++;

                    if (keyboardsCounter % 2==0)
                    {
                        expenses += displayPrice;
                    }
                }
                else if (i%3==0)
                {
                    expenses += mousePrice;
                }
                else if (i%2==0)
                {
                    expenses += headsetPrice;
                }
            }

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");

        }
    }
}
