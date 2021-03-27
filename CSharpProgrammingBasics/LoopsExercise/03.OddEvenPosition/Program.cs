using System;

namespace _03.OddEvenPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;

            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <=n; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (i%2==1)
                {
                    oddSum += number;
                    if (number<oddMin)
                    {
                        oddMin = number;
                    }
                    if (number>oddMax)
                    {
                        oddMax = number;
                    }
                }
                else
                {
                    evenSum += number;
                    if (number < evenMin)
                    {
                        evenMin = number;
                    }
                    if (number > evenMax)
                    {
                        evenMax = number;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");
            Console.WriteLine($"OddMin={(oddMin!=double.MaxValue? $"{oddMin:f2},":"No,")}");
            Console.WriteLine($"OddMax={(oddMax!=double.MinValue? $"{oddMax:f2},":"No,")}");

            Console.WriteLine($"EvenSum={evenSum:f2},");
            Console.WriteLine($"EvenMin={(evenMin != double.MaxValue ? $"{evenMin:f2}," : "No,")}");
            Console.WriteLine($"EvenMax={(evenMax != double.MinValue ? $"{evenMax:f2}" : "No")}");

        }
    }
}
