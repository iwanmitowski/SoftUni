using System;

namespace _07.SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nightStands = int.Parse(Console.ReadLine());

            decimal pricePerNight = 0;
            string sport = string.Empty;

            switch (season)
            {
                case "Winter":
                    if (groupType=="boys"||groupType=="girls")
                    {
                        pricePerNight = 9.6M;
                        if (groupType=="boys")
                        {
                            sport = "Judo";
                        }
                        else
                        {
                            sport = "Gymnastics";
                        }
                    }
                    else
                    {
                        pricePerNight = 10;
                        sport = "Ski";
                    }
                    break;
                case "Spring":
                    if (groupType == "boys" || groupType == "girls")
                    {
                        pricePerNight = 7.2M;
                        if (groupType == "boys")
                        {
                            sport = "Tennis";
                        }
                        else
                        {
                            sport = "Athletics";
                        }
                    }
                    else
                    {
                        pricePerNight = 9.5M;
                        sport = "Cycling";
                    }
                    break;
                case "Summer":
                    if (groupType == "boys" || groupType == "girls")
                    {
                        pricePerNight = 15;
                        if (groupType == "boys")
                        {
                            sport = "Football";
                        }
                        else
                        {
                            sport = "Volleyball";
                        }
                    }
                    else
                    {
                        pricePerNight = 20;
                        sport = "Swimming";
                    }
                    break;
                default:
                    break;
            }

            decimal totalSum = pricePerNight * nightStands*students;

            if (students>=50)
            {
                totalSum *= 0.5M;
            }
            else if (students>=20&&students<50)
            {
                totalSum *= 0.85M;
            }
            else if (students >= 10 && students < 20)
            {
                totalSum *= 0.95M;
            }


            Console.WriteLine($"{sport} {totalSum:f2} lv.");
        }
    }
}
