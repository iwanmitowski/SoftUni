using System;

namespace _04.BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int mm = int.Parse(Console.ReadLine());

            mm += 30;

            if (mm>=60)
            {
                mm -= 60;
                h++;

                if (h==24)
                {
                    h =0;
                }
            }

            Console.WriteLine($"{h}:{mm:d2}");
        }
    }
}
