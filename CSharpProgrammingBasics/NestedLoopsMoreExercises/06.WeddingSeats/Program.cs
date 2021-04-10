using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seatsOdd = int.Parse(Console.ReadLine());
            int seatsEven = seatsOdd + 2;

            int totalGuests = 0;

            for (int i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    int currentSeats = j % 2 == 0 ? seatsEven : seatsOdd;
                    
                    for (int k ='a'; k < 'a'+ currentSeats; k++)
                    {
                        Console.WriteLine($"{(char)i}{j}{(char)k}");
                        totalGuests++;
                    }
                }
                rows++;
            }

            Console.WriteLine(totalGuests);
        }
    }
}
