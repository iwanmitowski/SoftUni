using System;

namespace _04.InchesToCentimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());

            double cm = 2.54 * inch;
            Console.WriteLine(cm);
        }
    }
}
