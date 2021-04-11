using System;

namespace _01.ChangeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal bitcoin = 1168; //lv
            decimal chinese = 0.15M; //dolara
            decimal dolar = 1.76M;//lv
            decimal euro = 1.95M; //lv

            decimal bitcoins = decimal.Parse(Console.ReadLine());
            decimal chineseUana = decimal.Parse(Console.ReadLine());
            decimal comission = decimal.Parse(Console.ReadLine());

            decimal currentBitcoin = bitcoin * bitcoins;//lv
            decimal currentUans = (chinese * chineseUana) * dolar;//lv
            decimal finalPrice = (currentBitcoin + currentUans) / euro; //in euro
            Console.WriteLine($"{finalPrice - finalPrice * (comission / 100):f2}");



        }
    }
}
