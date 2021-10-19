using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int mostExpensiveSet = int.MinValue;

            int currentHat = -1;
            int currentScarf = -1;
            bool areEqual = false;

            var sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                if (!areEqual)
                {
                    currentHat = hats.Peek();
                }
                else
                {
                    areEqual = false;
                }

                currentScarf = scarfs.Peek();


                if (currentHat > currentScarf)
                {
                    int currentSet = currentHat + currentScarf;

                    if (currentSet > mostExpensiveSet)
                    {
                        mostExpensiveSet = currentSet;
                    }

                    sets.Add(currentSet);

                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (currentHat < currentScarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    currentHat++;
                    areEqual = true;
                }
            }

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
