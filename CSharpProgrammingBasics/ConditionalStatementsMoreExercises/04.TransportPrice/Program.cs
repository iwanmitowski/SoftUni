using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int kms = int.Parse(Console.ReadLine());
            string timeOfTheDay = Console.ReadLine();

            double taxiPrice = 0.7;
            double busPrice=0;
            double trainPrice=0;


            if (timeOfTheDay == "day")
            {
                taxiPrice += 0.79 * kms;
            }
            else
            {
                taxiPrice += 0.9 * kms;
            }

            
            if (kms >= 20)
            {
                busPrice = 0.09 * kms;
            }
            if (kms>=100)
            {
                trainPrice = 0.06 * kms;
            }


            List<double> prices = new List<double>(3) { taxiPrice, busPrice, trainPrice };

            Console.WriteLine($"{prices.Where(p=>p!=0).Min():f2}");

        }
    }
}
