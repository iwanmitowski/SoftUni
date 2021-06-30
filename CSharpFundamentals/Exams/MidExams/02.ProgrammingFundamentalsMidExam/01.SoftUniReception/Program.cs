using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsPerHour = 0;

            for (int i = 0; i < 3; i++)
            {
                studentsPerHour += int.Parse(Console.ReadLine());
            }

            int studentsWaiting = int.Parse(Console.ReadLine());

            int hours = 0;

            while (studentsWaiting>0)
            {
                studentsWaiting -= studentsPerHour;
                hours ++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
