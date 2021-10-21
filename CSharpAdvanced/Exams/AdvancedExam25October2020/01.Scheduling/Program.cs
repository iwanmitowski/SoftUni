using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                if (tasks.Peek() == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToBeKilled}");
                    break;
                }

                if (tasks.Peek() <= threads.Peek())
                {
                    tasks.Pop();
                }

                threads.Dequeue();
            }

            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
