using System;

namespace _05.DivisionWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num%4==0)
                {
                    p4++;
                }
                if (num%3==0)
                {
                    p3++;
                }
                if (num%2==0)
                {
                    p2++;
                }
            }

            Console.WriteLine($"{p2/n*100}%");
            Console.WriteLine($"{p3/n*100}%");
            Console.WriteLine($"{p4/n*100}%");
        }
    }
}
