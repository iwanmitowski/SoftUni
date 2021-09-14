using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    indexes.Push(i);
                }
                else if (input[i]==')')
                {
                    int openIndex = indexes.Pop();
                    int closingIndex = i;

                    Console.WriteLine(input.Substring(openIndex,closingIndex-openIndex+1));
                }
            }
        }
    }
}
