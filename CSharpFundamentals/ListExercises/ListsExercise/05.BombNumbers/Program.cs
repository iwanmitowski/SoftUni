using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int specialNumber = arguments[0];
            int power = arguments[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int left = i - power;
                int right = i + power;

                if (numbers[i] == specialNumber)
                {
                    if (left < 0)
                    {
                        left = 0;
                    }

                    if (right > numbers.Count)
                    {
                        right = numbers.Count - 1;
                    }

                    numbers.RemoveRange(left, right - left + 1);

                    i = -1;
                }
            }

            Console.WriteLine(numbers.Sum());

        }
    }
}
