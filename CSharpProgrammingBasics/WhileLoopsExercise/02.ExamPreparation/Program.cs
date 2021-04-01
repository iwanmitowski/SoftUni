using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFails = int.Parse(Console.ReadLine());

            int currentFails = 0;

            int numberOfProblems = 0;
            double averageGrades = 0;
            string lastProblem = string.Empty;


            while (currentFails < maxFails)
            {
                string problem = Console.ReadLine();

                if (problem == "Enough")
                {
                    break;
                }

                numberOfProblems++;
                lastProblem = problem;

                int grade = int.Parse(Console.ReadLine());
                averageGrades += grade;
                if (grade<=4)
                {
                    currentFails++;
                }
            }



            if (currentFails == maxFails)
            {
                Console.WriteLine($"You need a break, {maxFails} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {averageGrades/numberOfProblems:f2}");
                Console.WriteLine($"Number of problems: {numberOfProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
