using System;

namespace _05.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int extraWorkers = int.Parse(Console.ReadLine());

            double normalHoursWorked = days * 0.9 * 8;
            double extraHoursWorked = extraWorkers * (2 * days);

            int totalHours = (int)Math.Floor(normalHoursWorked + extraHoursWorked);

            if (totalHours>=neededHours)
            {
                Console.WriteLine($"Yes!{totalHours-neededHours} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{neededHours-totalHours} hours needed.");
            }


        }
    }
}
