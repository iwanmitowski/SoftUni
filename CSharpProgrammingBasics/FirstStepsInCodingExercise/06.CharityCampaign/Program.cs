using System;

namespace _06.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakePrice = 45;
            double gofrettePrice = 5.80;
            double pancakePrice = 3.20;

            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakesCount = int.Parse(Console.ReadLine());
            int goffretesCount = int.Parse(Console.ReadLine());
            int pancakesCount = int.Parse(Console.ReadLine());

            double cakesSum = cakesCount * cakePrice;
            double gofretteSum = goffretesCount * gofrettePrice;
            double pancakeSum = pancakesCount * pancakePrice;

            double totalSumForDay = (cakesSum + gofretteSum + pancakeSum) * bakers;
            
            double totalCampaignSum = totalSumForDay * days;
            
            double costs = totalCampaignSum / 8;

            double finalSum = totalCampaignSum - costs;

            Console.WriteLine(finalSum);

        }
    }
}
