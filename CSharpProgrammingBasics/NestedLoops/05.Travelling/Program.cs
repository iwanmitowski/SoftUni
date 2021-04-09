using System;

namespace _05.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = 0;
            double currentMoney = 0;

            string destination = Console.ReadLine();

            while (destination != "End")
            {
                neededMoney = double.Parse(Console.ReadLine());


                while (currentMoney < neededMoney)
                {
                    currentMoney += double.Parse(Console.ReadLine());
                }



                Console.WriteLine($"Going to {destination}!");
                currentMoney = 0;

                destination = Console.ReadLine();
            }
        }
    }
}
