using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(
                number == 1 ? "Monday" :
                number == 2 ? "Tuesday" :
                number == 3 ? "Wednesday" :
                number == 4 ? "Thursday" :
                number == 5 ? "Friday" :
                number == 6 ? "Saturday" :
                number == 7 ? "Sunday"
                : "Error");
        }
    }
}
