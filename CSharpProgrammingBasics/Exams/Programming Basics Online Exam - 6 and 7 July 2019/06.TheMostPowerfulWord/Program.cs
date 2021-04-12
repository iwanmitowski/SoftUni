using System;
using System.Linq;

namespace _06.TheMostPowerfulWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int maxScore = int.MinValue;
            string mostPowerfulWord = string.Empty;

            while (word != "End of words")
            {
                int wordLength = word.Length;
                double wordSum = word.Select(x => (int)x).Sum();
                int currentScore = 0;

                switch (word.ToLower()[0])
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'y':
                        currentScore = (int)Math.Floor(wordLength * wordSum);
                        break;
                    default:
                        currentScore = (int)Math.Floor(wordSum / wordLength);
                        break;
                }

                if (currentScore>maxScore)
                {
                    maxScore = currentScore;
                    mostPowerfulWord = word;
                }

                word = Console.ReadLine();
            }

            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {maxScore}");
        }
    }
}
