using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            double result = Calculate(command, n1, n2);

            Console.WriteLine(result);

        }

        private static double Calculate(string command, int n1, int n2)
        {
            switch (command)
            {
                case "add":
                    return n1 + n2;
                case "multiply":
                    return n1 * n2;
                case "subtract":
                    return n1 - n2;
                case "divide":
                    return n1 / n2;
            }

            return 0;
        }
    }
}
