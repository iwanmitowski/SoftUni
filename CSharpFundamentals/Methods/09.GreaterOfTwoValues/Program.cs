using System;
using System.Collections;
using System.Net.Http.Headers;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            switch (value)
            {
                case "int":
                    Console.WriteLine(
                            Compare(int.Parse(first), int.Parse(second))
                        );
                    break;
                case "char":
                    Console.WriteLine(
                        Compare(char.Parse(first), char.Parse(second))
                    );
                    break;
                default:
                    Console.WriteLine(Compare(first,second));
                    break;
            }

        }

        private static T Compare<T>(T t1, T t2) where T : IComparable
        {
            if (t1.CompareTo(t2)<0)
            {
                return t2;
            }

            return t1;
        }
    }
}
