using System;

namespace _04.TribonacciSequence
{
    class Program
    {
        static long n1 = 1;
        static long n2 = 1;
        static long n3 = 2;

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTribonacci(num);
        }

        private static void PrintTribonacci(int num)
        {
            if (num<=0)
            {
                Console.WriteLine(0);
            }
            else if (num == 1 || num == 2)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.Write(n1 + " ");
                }
                return;
            }
            else if (num >= 3)
            {
                Console.Write(n1 + " " + n2 + " " + n3);
                if (num==3)
                {
                    return;
                }
            }

            for (int i = 4; i <= num; i++)
            {
                long prevN1 = n1;

                n1 = n2;
                n2 = n3;
                n3 = n1 + n2 + prevN1;

                Console.Write(" " + n3);
            }
        }
    }
}
