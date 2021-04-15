using System;

namespace _06.HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = goal-30; i <= goal; i+=5)
            {
                int fails = 0;
                bool isJumped = true;

                for (int j = 0; j < 3; j++)
                {
                    count++;
                    int jump = int.Parse(Console.ReadLine());
                    if (jump<=i)
                    {
                        fails++;
                        if (fails==3)
                        {
                            isJumped = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (!isJumped)
                {
                    Console.WriteLine($"Tihomir failed at {i}cm after {count} jumps.");
                    Environment.Exit(0);
                }

            }
            Console.WriteLine($"Tihomir succeeded, he jumped over {goal}cm after {count} jumps.");

        }
    }
}
