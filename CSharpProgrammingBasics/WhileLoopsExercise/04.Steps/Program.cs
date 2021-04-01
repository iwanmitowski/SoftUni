using System;

namespace _04.Steps
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;

            int currentSteps = 0;
            bool isGoingHome = false;

            while (currentSteps<goal)
            {
                string input = Console.ReadLine();

                if (input=="Going home")
                {
                    isGoingHome = true;
                    break;
                }

                int steps = int.Parse(input);

                currentSteps += steps;

            }

            if (isGoingHome)
            {
                int goingHomeSteps = int.Parse(Console.ReadLine());
                currentSteps += goingHomeSteps;
            }
            
            if (currentSteps>=goal)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{currentSteps-goal} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goal-currentSteps} more steps to reach goal.");
            }


        }
    }
}
