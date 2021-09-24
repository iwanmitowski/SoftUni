using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(currentNum))
                {
                    dictionary.Add(currentNum, 0);
                }

                dictionary[currentNum]++;
            }

            int result = dictionary.Where(x => x.Value % 2 == 0).Select(x=>x.Key).First();

            Console.WriteLine(result);
        }
    }
}
