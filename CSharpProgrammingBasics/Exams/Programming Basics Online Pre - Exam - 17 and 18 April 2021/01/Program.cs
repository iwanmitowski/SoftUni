using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double processor = double.Parse(Console.ReadLine())*1.57;
            double gpu = double.Parse(Console.ReadLine()) * 1.57;
            double ram = double.Parse(Console.ReadLine()) * 1.57;
            int ramCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            processor -= (processor * discount);
            gpu -= (gpu * discount);
            double totalSum = processor + gpu + ram * ramCount;

            Console.WriteLine($"Money needed - {totalSum:f2} leva.");
        }
    }
}
