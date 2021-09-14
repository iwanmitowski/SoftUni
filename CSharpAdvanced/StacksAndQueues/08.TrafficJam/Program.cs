using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int canPass = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            var traffic = new Queue<string>();
            int passed = 0;

            while (input!="end")
            {
                if (input=="green")
                {
                    for (int i = 0; i < canPass; i++)
                    {
                        if (traffic.TryPeek(out _))
                        {
                            Console.WriteLine($"{traffic.Dequeue()} passed!");
                            passed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    traffic.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passed} cars passed the crossroads.");
        }
    }
}
