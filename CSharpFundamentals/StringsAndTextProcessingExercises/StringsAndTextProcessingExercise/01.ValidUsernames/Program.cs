using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (var un in usernames)
            {
                bool isValid = true;

                if (un.Length >= 3 && un.Length <= 16)
                {
                    foreach (var x in un)
                    {
                        if (x != '_' && x != '-' && !char.IsLetterOrDigit(x))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(un);
                    }

                    
                }
            }
        }
    }
}
