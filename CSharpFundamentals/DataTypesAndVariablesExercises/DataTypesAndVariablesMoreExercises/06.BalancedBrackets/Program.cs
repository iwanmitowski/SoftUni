using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int left = 0;
            int right = 0;
            bool isOpen = false;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    left++;
                    if (isOpen)
                    {
                        break;
                    }
                    isOpen = true;
                }
                else if (input == ")" && isOpen)
                {
                    right++;
                    isOpen = false;
                }
            }

            string result = left == right ? "BALANCED" : "UNBALANCED";

            Console.WriteLine(result);
        }
    }
}
