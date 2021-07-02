using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int peoplePerHour = 0;

            for (int i = 0; i < 3; i++)
            {
                peoplePerHour += int.Parse(Console.ReadLine());
            }

            int totalPeople = int.Parse(Console.ReadLine());
            int hours = 0;

            while (totalPeople > 0)
            {
                totalPeople -= peoplePerHour;
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
