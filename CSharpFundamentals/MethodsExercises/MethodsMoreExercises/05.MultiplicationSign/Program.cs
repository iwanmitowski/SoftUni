using System;
using System.Linq;
using System.Xml.Serialization;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            if (numbers.All(x=>x>0))
            {
                Console.WriteLine("positive");
            }
            else if (numbers.Any(x=>x ==0))
            {
                Console.WriteLine("zero");
            }
            else if (numbers.Any(x=>x<0))
            {
                Console.WriteLine("negative");
            }
        }
    }
}
