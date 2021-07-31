using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            //C# backreferences dont count named capture groups for backreferences.

            string pattern = @"\b(?<day>[\d]{2})([\/.-])(?<month>[A-Z][a-z]{2})\1(?<year>[\d]{4})\b";
            Regex regex = new Regex(pattern);

            string dates = Console.ReadLine();

            var matches = regex.Matches(dates);
            foreach (Match match in matches)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
