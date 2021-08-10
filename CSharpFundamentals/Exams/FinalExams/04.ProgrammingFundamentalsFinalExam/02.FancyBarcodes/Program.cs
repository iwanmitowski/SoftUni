using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@[#]+(?<word>[A-Z][A-Za-z0-9]{4,}[A-Z])\@[#]+";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var match = Regex.Match(Console.ReadLine(), pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                
                string digits = string.Join("", match.Groups["word"].Value.Where(x => char.IsDigit(x)).ToList());

                if (string.IsNullOrWhiteSpace(digits))
                {
                    digits = "00";
                }

                Console.WriteLine($"Product group: {digits}");
            }
        }
    }
}
