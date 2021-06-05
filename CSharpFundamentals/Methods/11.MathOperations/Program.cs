using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int n2 = int.Parse(Console.ReadLine());

            double result = Calculate(n1, command, n2);

            Console.WriteLine($"{result}");
        }

        private static double Calculate(int n1, string command, int n2)
        {
            double result = 0;

            switch (command)
            {
                case "+":
                    result = n1 + n2;
                    break;
                
                case "-":
                    result = n1 - n2;
                    break;
                
                case "*":
                    result = n1 * n2;
                    break;
                
                case "/":
                    result = n1 / n2;
                    break;

            }

            return result;
        }
    }
}
