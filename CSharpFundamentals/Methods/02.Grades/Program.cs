using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine(Result(grade));
        }

        private static string Result(double grade)
        {
            if (grade >= 2 && grade < 3)
            {
                return "Fail";
            }
            else if (grade >= 3 && grade < 3.5)
            {
                return "Poor";
            }
            else if (grade >= 3.5 && grade < 4.5)
            {
                return "Good";
            }
            else if (grade >= 4.5 && grade < 5.5)
            {
                return "Very good";
            }
            else if (grade >= 5.5 && grade <= 6)
            {
                return "Excellent";
            }

            return null;
        }
    }
}
