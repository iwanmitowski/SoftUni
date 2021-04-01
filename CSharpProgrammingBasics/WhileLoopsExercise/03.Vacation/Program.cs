using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            int spendingSpree = 0;
            int days = 0;

            while (currentMoney < neededMoney && spendingSpree < 5)
            {
                string activity = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                days++;

                if (activity == "spend")
                {
                    spendingSpree++;
                    currentMoney -= money;

                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }

                }
                else
                {
                    spendingSpree = 0;
                    currentMoney += money;
                }

            }

            if (spendingSpree == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }
            else if (currentMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }

        }
    }
}
