using System;

namespace _01.OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statues = rent * 0.7;
            double catering = statues * 0.85;
            double sound = catering / 2;

            double totalSum = rent + statues + catering + sound;
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
