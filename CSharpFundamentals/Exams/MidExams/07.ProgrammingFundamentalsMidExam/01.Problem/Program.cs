using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            double earnedExperience = 0;

            bool isEnough = false;



            for (int i = 1; i <= battlesCount; i++)
            {
                double currentExperience = double.Parse(Console.ReadLine());

                if (i % 3 == 0 & i % 5 == 0)
                {
                    currentExperience *= 1.05;
                }
                else if (i % 3 == 0)
                {
                    currentExperience *= 1.15;
                }
                else if (i % 5 == 0)
                {
                    currentExperience *= 0.9;
                }

                earnedExperience += currentExperience;

                if (earnedExperience >= neededExperience)
                {
                    isEnough = true;
                    battlesCount = i;
                    break;
                }
            }

            if (isEnough)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesCount} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience-earnedExperience:f2} more needed.");
            }
        }
    }
}
