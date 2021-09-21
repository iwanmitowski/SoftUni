using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = new HashSet<string>();
            var vips = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (char.IsDigit(input[0]))
                {
                    vips.Add(input);
                }
                else
                {
                    guests.Add(input);
                }

                input = Console.ReadLine();
            }

            string comeingGuests = Console.ReadLine();

            while (comeingGuests != "END")
            {
                guests.Remove(comeingGuests);
                vips.Remove(comeingGuests);

                comeingGuests = Console.ReadLine();
            }

            Console.WriteLine(guests.Count() + vips.Count());

            foreach (var vip in vips)
            {
                Console.WriteLine(vip);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
