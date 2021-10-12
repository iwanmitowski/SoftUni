using System;
using System.Linq;

namespace Threeple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            string name = $"{first[0]} {first[1]}";
            string address = first[2];
            string town = string.Join(" ", first.Skip(3));

            var firstThreeuple = new Threeuple<string, string, string>(name, address, town);
            Console.WriteLine(firstThreeuple);

            string[] second = Console.ReadLine().Split();
            var secondThreeuple = new Threeuple<string, int, bool>(second[0], int.Parse(second[1]), second[2].ToLower() == "drunk");
            Console.WriteLine(secondThreeuple);

            string[] third = Console.ReadLine().Split();
            var thirdThreeuple = new Threeuple<string, double, string>(third[0], double.Parse(third[1]), third[2]);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
