using System;

namespace _04.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            double grpOf5 = 0;
            double grpOf6to12 = 0;
            double grpOf13to25 = 0;
            double grpOf26to40 = 0;
            double grpOf41 = 0;

            int totalClimbers = 0;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int currentClimbers = int.Parse(Console.ReadLine());
                totalClimbers += currentClimbers;

                if (currentClimbers<=5)
                {
                    grpOf5 += currentClimbers;
                }
                else if (currentClimbers>=6&&currentClimbers<=12)
                {
                    grpOf6to12 += currentClimbers;
                }
                else if (currentClimbers>=13&&currentClimbers<=25)
                {
                    grpOf13to25 += currentClimbers;
                }
                else if (currentClimbers>=26&&currentClimbers<=40)
                {
                    grpOf26to40 += currentClimbers;
                }
                else 
                {
                    grpOf41 += currentClimbers;
                }
            }

            Console.WriteLine($"{grpOf5/totalClimbers*100:f2}%");
            Console.WriteLine($"{grpOf6to12/totalClimbers*100:f2}%");
            Console.WriteLine($"{grpOf13to25/totalClimbers*100:f2}%");
            Console.WriteLine($"{grpOf26to40/totalClimbers*100:f2}%");
            Console.WriteLine($"{grpOf41/totalClimbers*100:f2}%");
        }
    }
}
