using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<furniture>\w+)<<(?<price>\d+.?\d+)!(?<quantity>\d+)";

            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            decimal totalPrice = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bought furniture:");

            while (input!="Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string furniture = match.Groups["furniture"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quanity = int.Parse(match.Groups["quantity"].Value);

                    sb.AppendLine(furniture);

                    totalPrice += price * quanity;
                }

                input = Console.ReadLine();
            }

            sb.AppendLine($"Total money spend: {totalPrice:f2}");

            Console.WriteLine(sb.ToString());
        }
    }
}
