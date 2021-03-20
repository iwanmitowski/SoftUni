using System;

namespace _04.PersonalTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            double years = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            switch (gender)
            {
                case "m":
                    if (years >= 16)
                    {
                        Console.WriteLine("Mr.");

                    }
                    else
                    {
                        Console.WriteLine("Master");

                    }
                    break;

                case "f":
                    if (years >= 16)
                    {
                        Console.WriteLine("Ms.");

                    }
                    else
                    {
                        Console.WriteLine("Miss");

                    }
                    break;
                default:
                    break;
            }
        }
    }
}
