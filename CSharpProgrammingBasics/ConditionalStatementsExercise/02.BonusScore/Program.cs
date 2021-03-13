using System;

namespace _02.BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonus = 0.0;

            bonus += number <= 100 ? 5 :
                     number > 100 && number <= 1000 ? number * 0.2 :
                     number * 0.1;

            bonus += number % 2 == 0 ? 1 : 0;
            bonus += number % 10 == 5 ? 2 : 0;

            Console.WriteLine(bonus);
            Console.WriteLine(number + bonus);

        }
    }
}
