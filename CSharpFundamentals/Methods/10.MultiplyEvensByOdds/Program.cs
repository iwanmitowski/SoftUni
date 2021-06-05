using System;
using System.Linq;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            
            int sumEvens = GetEvenSum(number);
            int sumOdds = GetOddSum(number);
            int mult = GetMult(sumEvens, sumOdds);

            Console.WriteLine(mult);
        }

        private static int GetMult(int sumEvens, int sumOdds)
        {
            return sumEvens * sumOdds;
        }

        private static int GetEvenSum(string number)
        {
            int sum = 0;

            foreach (var d in number)
            {
                if (int.TryParse(d.ToString(),out int num) && num%2==0)
                {
                    sum += num;
                }
            }

            return sum;
        }

        private static int GetOddSum(string number)
        {
            int sum = 0;

            foreach (var d in number)
            {
                if (int.TryParse(d.ToString(),out int num) && num%2!=0)
                {
                    sum += num;
                }
            }

            return sum;
        }
    }
}
