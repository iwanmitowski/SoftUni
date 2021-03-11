using System;

namespace _10.Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftRight = (n - 1) / 2;

            string dash = "-";
            string star = "*";

            while (leftRight!=0)
            {
                int mid = n - 2 * leftRight - 2;

                for (int j = 0; j < leftRight; j++)
                {
                    Console.Write(dash);
                }

                Console.Write(star);

                for (int k = 0; k < mid; k++)
                {
                    Console.Write(dash);
                }


                if (mid >= 0)
                {
                    Console.Write(star);

                }


                for (int j = 0; j < leftRight; j++)
                {
                    Console.Write(dash);
                }
                Console.WriteLine();
                leftRight--;
            }


            int reps;

            if (n%2==0)
            {
                reps = n / 2;
            }
            else
            {
                reps = n / 2 + 1;
            }

            while (leftRight < reps)
            {
                int mid = n - 2 * leftRight - 2;

                for (int j = 0; j < leftRight; j++)
                {
                    Console.Write(dash);
                }

                Console.Write(star);

                for (int k = 0; k < mid; k++)
                {
                    Console.Write(dash);
                }


                if (mid >= 0)
                {
                    Console.Write(star);

                }


                for (int j = 0; j < leftRight; j++)
                {
                    Console.Write(dash);
                }
                Console.WriteLine();
                leftRight++;
            }


        }

    }
}

