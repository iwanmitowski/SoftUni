using System;

namespace _04.TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judges = int.Parse(Console.ReadLine());
            string project = Console.ReadLine();

            double finalGrade = 0;
            double gradeCounter = 0;
                        
            while (project != "Finish")
            {
                double currentGrades = 0;
               
                for (int i = 0; i < judges; i++)
                {
                    double givenGrade = double.Parse(Console.ReadLine());
                    currentGrades += givenGrade;
                    finalGrade += givenGrade;
                    gradeCounter++;
                }

                Console.WriteLine($"{project} - {currentGrades / judges:f2}.");

                project = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {finalGrade / gradeCounter:f2}.");
        }
    }
}
