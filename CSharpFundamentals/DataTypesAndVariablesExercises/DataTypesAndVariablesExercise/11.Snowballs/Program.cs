using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int biggestSnow = 0;
            int biggestTime = 0;
            int biggestQuality = 0;
            BigInteger biggestValue = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue>biggestValue)
                {
                    biggestSnow = snowballSnow;
                    biggestTime = snowballTime;
                    biggestQuality = snowballQuality;
                    biggestValue = snowballValue;
                }
            }

            Console.WriteLine($"{biggestSnow} : {biggestTime} = {biggestValue} ({biggestQuality})");
        }
    }
}
