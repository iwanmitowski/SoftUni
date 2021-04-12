using System;

namespace _04.CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int voucher = int.Parse(Console.ReadLine());

            string movie = Console.ReadLine();

            int ticket = 0;
            int food = 0;

            while (movie!="End")
            {
                int sum = 0;
               
                if (movie.Length>8)
                {
                    if ((int)movie[0] + (int)movie[1] > voucher)
                    {
                        break;
                    }
                    sum = (int)movie[0] + (int)movie[1];
                    ticket++;
                }
                else
                {
                    if ((int)movie[0] > voucher)
                    {
                        break;
                    }
                    sum = (int)movie[0];
                    food++;
                }

                voucher -= sum;
                movie = Console.ReadLine();
            }

            Console.WriteLine(ticket);
            Console.WriteLine(food);
        }
    }
}
