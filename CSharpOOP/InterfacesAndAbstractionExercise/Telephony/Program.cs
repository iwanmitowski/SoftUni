using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var sites = Console.ReadLine().Split();

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.All(x => char.IsDigit(x)) && number.Length == 10)
                {
                    smartPhone.Calling(number);
                }
                else if (number.All(x => char.IsDigit(x)) && number.Length == 7)
                {
                    stationaryPhone.Dial(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var url in sites)
            {
                if (url.All(x => !char.IsDigit(x)))
                {
                    Console.WriteLine($"Browsing: {url}!");
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
