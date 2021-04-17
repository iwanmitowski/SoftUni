using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double kgs = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());

            double price = 0;
            double transport = 0;
            switch (type)
            {
                case "standard":
                    if (kgs<1)
                    {
                        price = 0.03;
                        transport = distance * 0.03;
                    }
                    else if (kgs>=1&&kgs<10)
                    {
                        price = 0.05;
                        transport = distance * 0.05;
                    }
                    else if (kgs>=10&&kgs<40)
                    {
                        price = 0.1;
                        transport = distance * 0.1;

                    }
                    else if (kgs>=40&&kgs<90)
                    {
                        price = 0.15;
                        transport = distance * 0.15;

                    }
                    else
                    {
                        price = 0.2;
                        transport = distance * 0.2;

                    }
                    break;
                case "express":
                    if (kgs < 1)
                    {
                        price = 0.03 * 0.8;
                        transport = distance * 0.03;
                    }
                    else if (kgs > 1 && kgs <= 10)
                    {
                        price = 0.03 * 0.4;
                        transport = distance * 0.05;
                    }
                    else if (kgs>10&&kgs<40)
                    {

                        price = 0.05 * 0.1;
                        transport = distance * 0.1;
                    }
                    else if (kgs >= 40 && kgs < 90)
                    {
                        price = 0.15 * 0.02;
                        transport = distance * 0.15;

                    }
                    else
                    {
                        price = 0.2 * 0.01;
                        transport = distance * 0.2;

                    }
                    break;
            }
            double totalPrice = 0;
            if (type=="express")
            {
                totalPrice = kgs * price * distance+transport;
                
            }
            else 
            {
                totalPrice = price*distance;
            }
            Console.WriteLine($"The delivery of your shipment with weight of {kgs:f3} kg. would cost {totalPrice:f2} lv.");
        }
    }
}
