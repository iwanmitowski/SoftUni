using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();

            double result = 0;

            if ((@operator == "/" || @operator == "%") && n2 == 0)
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
                Environment.Exit(0);
            }

            switch (@operator)
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
                    Console.WriteLine($"{n1} {@operator} {n2} = {result:f2}");
                    Environment.Exit(0);
                    break;
                case "%":
                    result = n1 % n2;
                    Console.WriteLine($"{n1} {@operator} {n2} = {result}");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            if (@operator == "+" || @operator == "-" || @operator == "*")
            {
                Console.WriteLine($"{n1} {@operator} {n2} = {result} {(result % 2 == 0 ? "- even" : "- odd")}");
            }
            
        }
    }
}
