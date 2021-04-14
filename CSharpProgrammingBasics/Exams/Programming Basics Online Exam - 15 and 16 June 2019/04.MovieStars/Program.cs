using System;

namespace _04.MovieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double actorsBudget = double.Parse(Console.ReadLine());

            string actor = Console.ReadLine();

            while (actor != "ACTION")
            {
                double salary;

                if (actor.Length <= 15)
                {
                    salary = double.Parse(Console.ReadLine());
                }
                else
                {
                    salary = actorsBudget * 0.2;
                }

                actorsBudget -= salary;
                if (actorsBudget <= 0)
                {
                    break;
                }

                actor = Console.ReadLine();
            }


            if (actorsBudget>=0)
            {
                Console.WriteLine($"We are left with {actorsBudget:f2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(actorsBudget):f2} leva for our actors.");
            }
        }
    }
}
