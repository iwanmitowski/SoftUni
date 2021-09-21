using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var parking = new HashSet<string>();

            while (input!="END")
            {
                string[] tokens = input.Split(", ");

                string command = tokens[0];
                string carNumber = tokens[1];

                if (command=="IN")
                {
                    parking.Add(carNumber);
                }
                else
                {
                    parking.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            if (parking.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine,parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
