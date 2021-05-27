using System;

namespace _01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            sum+= int.Parse(Console.ReadLine());
            sum/=int.Parse(Console.ReadLine());
            sum*=int.Parse(Console.ReadLine());
            Console.WriteLine(sum);
        }
    }
}
