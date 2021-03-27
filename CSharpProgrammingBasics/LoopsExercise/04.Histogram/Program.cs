using System;

namespace _04.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double p1 = 0;   
            double p2 = 0;   
            double p3 = 0;   
            double p4 = 0;   
            double p5 = 0;

            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                int i = int.Parse(Console.ReadLine());
                if (i<200)
                {
                    p1++;
                }
                else if (i>=200&&i<400)
                {
                    p2++;
                }
                else if (i>=400&&i<600)
                {
                    p3++;
                }
                else if (i>=600&&i<800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            p1 = (p1 / n) * 100;
            p2 = (p2 / n) * 100;
            p3 = (p3 / n) * 100;
            p4 = (p4 / n) * 100;
            p5 = (p5 / n) * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
