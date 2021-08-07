using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\#|\|)(?<item>[[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{0,5})\1";

            var matches = Regex.Matches(Console.ReadLine(), pattern);

            int cals = 0;

            StringBuilder sb = new StringBuilder();

            foreach (Match item in matches)
            {
                int calories = int.Parse(item.Groups["calories"].Value);
                sb.AppendLine($"Item: {item.Groups["item"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {calories}");

                cals += calories;
            }

            int days = cals / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            Console.WriteLine(sb.ToString());
        }
    }
}
