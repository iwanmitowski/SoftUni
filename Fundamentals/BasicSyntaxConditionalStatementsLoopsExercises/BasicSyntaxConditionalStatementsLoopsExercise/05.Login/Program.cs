using System;
using System.Linq;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string password = string.Join("",user.ToCharArray().Reverse());

            string input = Console.ReadLine();
            int counter = 0;

            while (input!=password)
            {
                counter++;
                if (counter==4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    Environment.Exit(0);
                }

                Console.WriteLine($"Incorrect password. Try again.");

                input = Console.ReadLine();
            }

            Console.WriteLine($"User {user} logged in.");
        }
    }
}
