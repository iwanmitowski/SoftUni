using System;

namespace _09.FuelTankPt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double fuelAmount = double.Parse(Console.ReadLine());
            string cardYesNo = Console.ReadLine();

            double gasoline = 2.22;
            double diesel = 2.33;
            double gas = 0.93;

            double discount;
            double finalPrice;
            double fuelPrice;

            if (fuelType == "Gasoline")
            {
                discount = 0.18;
                fuelPrice= gasoline;
            }
            else if (fuelType == "Diesel")
            {
                discount = 0.12;
                fuelPrice= diesel;
            }
            else
            {
                discount = 0.08;
                fuelPrice= gas;
            }

            if (cardYesNo=="Yes")
            {
                finalPrice = fuelAmount * (fuelPrice-discount);
            }
            else
            {
                finalPrice = fuelAmount * fuelPrice;
            }

            if (fuelAmount>=20&&fuelAmount<=25)
            {
                finalPrice *= 0.92;
            }
            else if (fuelAmount>25)
            {
                finalPrice *= 0.90;

            }

            Console.WriteLine($"{finalPrice:f2} lv.");
        }
    }
}
