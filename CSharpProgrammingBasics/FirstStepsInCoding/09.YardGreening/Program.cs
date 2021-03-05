using System;

namespace _09.YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine());
            double metersPerSq = 7.61;
            double sum = meters * metersPerSq;
            double discount = sum * 0.18;

            Console.WriteLine($"The final price is: {sum-discount} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
