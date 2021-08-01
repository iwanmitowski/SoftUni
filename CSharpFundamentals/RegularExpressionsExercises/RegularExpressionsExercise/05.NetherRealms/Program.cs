using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^0-9\+\-\*\/\.]";
            string damagePattern = @"[+-]?[\d]+\.?[\d]*";

            string[] demons = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < demons.Length; i++)
            {
                string d = demons[i];

                var health = Regex.Matches(d, healthPattern).Select(x => (int)char.Parse(x.Value)).Sum();
                var dmg = Regex.Matches(d, damagePattern).Select(x => double.Parse(x.Value)).Sum();

                foreach (var symbol in d.Where(x => x == '/' || x == '*'))
                {
                    if (symbol == '/')
                    {
                        dmg /= 2.0;
                    }
                    else
                    {
                        dmg *= 2.0;
                    }
                }

                demons[i] = $"{d} - {health} health, {dmg:f2} damage";
            }

            Console.WriteLine(string.Join(Environment.NewLine, demons.OrderBy(x => x)));

        }
    }
}
