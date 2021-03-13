using System;

namespace _05.TimePlus15Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;

            if (minutes>=60)
            {
                minutes -= 60;
                hours++;
            }
            if (hours==24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{(minutes < 10 ? $"0{minutes}" : $"{minutes}")}");
        }
    }
}
