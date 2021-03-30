using System;

namespace _05.GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());

            decimal from0To9 = 0;
            decimal from10To19 = 0;
            decimal from20To29 = 0;
            decimal from30To39 = 0;
            decimal from40To50 = 0;
            decimal invalid = 0;

            decimal finalResult = 0;

            for (int i = 0; i < turns; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0 || number > 50)
                {
                    invalid++;

                    finalResult /= 2;
                }
                else if (number >= 0 && number <= 9)
                {
                    from0To9++;

                    finalResult += number * 0.2M;
                }
                else if (number >= 10 && number <= 19)
                {
                    from10To19++;
                    finalResult += number * 0.3M;
                }
                else if (number >= 20 && number <= 29)
                {
                    from20To29++;
                    finalResult += number * 0.4M;
                }
                else if (number >= 30 && number <= 39)
                {
                    from30To39++;
                    finalResult += 50;
                }
                else if (number >= 40 && number <= 50)
                {
                    from40To50++;
                    finalResult += 100;
                }

            }

            Console.WriteLine($"{finalResult:f2}");
            Console.WriteLine($"From 0 to 9: {from0To9 / turns * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {from10To19 / turns * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {from20To29 / turns * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {from30To39 / turns * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {from40To50 / turns * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalid / turns * 100:f2}%");


        }
    }
}
