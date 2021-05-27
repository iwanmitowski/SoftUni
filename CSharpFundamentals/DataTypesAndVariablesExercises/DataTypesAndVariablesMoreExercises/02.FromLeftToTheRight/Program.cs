using System;
using System.Linq;
using System.Numerics;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] nums = Console.ReadLine().Split().ToArray();

                long digitsSum = 0;
                long n1 = long.Parse(nums[0]);
                long n2 = long.Parse(nums[1]);

                if (n1 > n2)
                {
                    foreach (var c in nums[0])
                    {
                        long.TryParse(c.ToString(), out long digit);
                        digitsSum += digit;
                    }
                }
                else
                {
                    foreach (var c in nums[1])
                    {
                        long.TryParse(c.ToString(), out long digit);
                        digitsSum += digit;
                    }
                }

                Console.WriteLine(digitsSum);
            }
        }
    }
}
