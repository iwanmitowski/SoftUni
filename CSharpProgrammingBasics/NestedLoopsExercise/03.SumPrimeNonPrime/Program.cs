using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sumPrime = 0;
            int sumNonPrime = 0;

            while (input != "stop")
            {
                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    input = Console.ReadLine();
                    continue;
                }

                bool isPrime = true;
                int counter = 0;

                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        counter++;
                        if (counter > 2)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                {
                    sumPrime += number;
                }
                else
                {
                    sumNonPrime += number;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
