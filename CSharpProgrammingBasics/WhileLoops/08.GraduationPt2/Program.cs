using System;

namespace _08.GraduationPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int excludedCount = 0;
            bool isExcluded = false;

            double averageMarks = 0;
            int gradesCount = 1;

            while (gradesCount <= 12)
            {
                double currentGradeMark = double.Parse(Console.ReadLine());

                if (currentGradeMark < 4)
                {
                    excludedCount++;

                    if (excludedCount == 2)
                    {
                        isExcluded = true;

                        break;
                    }

                    continue;
                }

                averageMarks += currentGradeMark;
                gradesCount++;

            }

            averageMarks /= gradesCount;

            if (isExcluded)
            {
                Console.WriteLine($"{name} has been excluded at {gradesCount} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageMarks:f2}");
            }
        }
    }
}
