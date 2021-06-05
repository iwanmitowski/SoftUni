using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = Pow(num, power);

            Console.WriteLine(result);
        }

        private static double Pow(double num, int power)
        {
            return Math.Pow(num, power);
        }
    }
}
