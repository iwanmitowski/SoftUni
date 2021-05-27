using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceForSabre = double.Parse(Console.ReadLine());
            double priceForRobe = double.Parse(Console.ReadLine());
            double priceForBelt = double.Parse(Console.ReadLine());

            int freeBelts = studentsCount / 6;

            double equipment = priceForSabre * (Math.Ceiling(studentsCount * 1.1)) + priceForRobe * studentsCount + priceForBelt * (studentsCount - freeBelts);

            if (money>=equipment)
            {
                Console.WriteLine($"The money is enough - it would cost {equipment:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {equipment-money:f2}lv more.");
            }

        }
    }
}
