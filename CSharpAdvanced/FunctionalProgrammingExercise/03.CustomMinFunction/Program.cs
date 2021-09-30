using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumber = numbers =>
             {
                 int minNumber = int.MaxValue;

                 foreach (var num in numbers)
                 {
                     if (num<minNumber)
                     {
                         minNumber = num;
                     }
                 }

                 return minNumber;
             };

            Console.WriteLine(minNumber(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()));
        }
    }
}
