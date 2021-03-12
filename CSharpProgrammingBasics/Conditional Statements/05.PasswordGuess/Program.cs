using System;

namespace _05.PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "s3cr3t!P@ssw0rd";

            string guess = Console.ReadLine();

            Console.WriteLine(guess == password ? "Welcome" : "Wrong password!");

        }
    }
}
