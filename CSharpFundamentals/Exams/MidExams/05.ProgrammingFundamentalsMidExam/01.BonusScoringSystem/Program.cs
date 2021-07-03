using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            double attendances = 0;


            for (int i = 0; i < studentsCount; i++)
            {
                double currAttendances = int.Parse(Console.ReadLine());
                double formula = currAttendances / lecturesCount * (5 + additionalBonus);

                if (formula > maxBonus)
                {
                    maxBonus = formula;
                    attendances = currAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {attendances} lectures.");
        }
    }
}
