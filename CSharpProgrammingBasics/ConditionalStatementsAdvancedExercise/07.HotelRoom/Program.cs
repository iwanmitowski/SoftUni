using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightstands = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double apartmentPrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;

                    if (nightstands > 7 && nightstands < 14)
                    {
                        studioPrice *= 0.95;
                    }
                    else if (nightstands > 14)
                    {
                        studioPrice *= 0.7;
                        apartmentPrice *= 0.9;
                    }
                    break;
                case "June":
                case "September":
                    studioPrice = 75.2;
                    apartmentPrice = 68.7;

                    if (nightstands > 14)
                    {
                        studioPrice *= 0.8;
                        apartmentPrice *= 0.9;
                    }
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    if (nightstands > 14)
                    {
                        apartmentPrice *= 0.9;
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine($"Apartment: {apartmentPrice*nightstands:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice*nightstands:f2} lv.");
        }
    }
}
