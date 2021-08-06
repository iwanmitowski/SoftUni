using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"([\$#\@\^])\1{5,9}";

            string[] input = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in input)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string left = ticket.Substring(0, 10);
                string right = ticket.Substring(10);

                var leftMatch = Regex.Match(left, pattern);
                var rightMatch = Regex.Match(right, pattern);

                if (!leftMatch.Success || !rightMatch.Success)
                {
                    Console.WriteLine($@"ticket ""{ticket}"" - no match");
                    continue;
                }

                int minLength = Math.Min(leftMatch.Length, rightMatch.Length);
                var symbol = leftMatch.Value[0];

                if (leftMatch.Value == rightMatch.Value)
                {
                    if (leftMatch.Length != 10)
                    {
                        Console.WriteLine($@"ticket ""{ticket}"" - {minLength}{symbol}");
                    }
                    else
                    {
                        Console.WriteLine($@"ticket ""{ticket}"" - 10{symbol} Jackpot!");
                    }
                }
                else
                {
                    Console.WriteLine($@"ticket ""{ticket}"" - {minLength}{symbol}");
                }

            }
        }
    }
}
