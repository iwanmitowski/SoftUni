using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();

            string input = Console.ReadLine();

            while (input!="End")
            {
                if (input=="Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
