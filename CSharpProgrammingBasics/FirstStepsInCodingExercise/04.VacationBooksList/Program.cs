using System;

namespace _04.VacationBooksList
{
    class Program
    {
        static void Main(string[] args)
        {
            int pagesCount = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double totalReadingTime = pagesCount / pagesPerHour;
            double timePerDay = totalReadingTime / days;
            Console.WriteLine(timePerDay);
        }
    }
}
