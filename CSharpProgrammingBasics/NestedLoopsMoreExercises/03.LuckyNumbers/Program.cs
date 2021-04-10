using System;
using System.Linq;

namespace _03.LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string numToString = i.ToString();

                if (numToString.Contains('0'))
                {
                    continue;
                }

                int firstDigits = int.Parse(numToString[0].ToString())+int.Parse(numToString[1].ToString());
                int secondDigits = int.Parse(numToString[2].ToString()) +int.Parse(numToString[3].ToString());
                
                if (firstDigits!=secondDigits||n%firstDigits!=0)
                {
                    continue;
                }

                Console.Write(i + " ");
            }
        }
    }
}
