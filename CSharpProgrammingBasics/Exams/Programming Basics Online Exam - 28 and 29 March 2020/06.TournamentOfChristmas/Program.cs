using System;

namespace _06.TournamentOfChristmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int wins = 0;
            int losses = 0;
            double totalMoney = 0;

            for (int i = 0; i < days; i++)
            {
                string input = Console.ReadLine();

                int currentWins = 0;
                int currentLosses = 0;
                double money = 0;

                while (input!="Finish")
                {
                    string state = Console.ReadLine();
                    if (state=="win")
                    {
                        wins++;
                        currentWins++;
                        money += 20;
                    }
                    else
                    {
                        losses++;
                        currentLosses++;
                    }

                    

                    input = Console.ReadLine();
                }
                if (currentWins > currentLosses)
                {
                    money *= 1.1;
                }
                totalMoney += money;
            }

            if (wins>losses)
            {
                totalMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");

            }


        }
    }
}
