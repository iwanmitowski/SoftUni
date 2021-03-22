using System;
using System.Globalization;

namespace _08.OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int totalExamMinutes = examHour * 60 + examMinutes;
            int totalArrivalMinutes = arrivalHour * 60 + arrivalMinutes;

            if (totalExamMinutes < totalArrivalMinutes)
            {
                Console.WriteLine("Late");

                int diff = totalArrivalMinutes - totalExamMinutes;
                int h = diff / 60;
                int m = diff % 60;

                if (diff < 60)
                {
                    Console.WriteLine($"{diff} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{h}:{m:D2} hours after the start");
                }
            }
            else if (totalExamMinutes - totalArrivalMinutes <= 30 || totalExamMinutes - totalArrivalMinutes == 0)
            {
                Console.WriteLine("On time");

                if (totalExamMinutes != totalArrivalMinutes)
                {
                    int diff = totalExamMinutes - totalArrivalMinutes;


                    Console.WriteLine($"{diff%60} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Early");

                int diff = totalExamMinutes - totalArrivalMinutes;
                int h = diff / 60;
                int m = diff % 60;

                if (totalExamMinutes - totalArrivalMinutes >= 60)
                {
                    Console.WriteLine($"{h}:{m:D2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{diff} minutes before the start");
                }
            }
        }
    }
}
