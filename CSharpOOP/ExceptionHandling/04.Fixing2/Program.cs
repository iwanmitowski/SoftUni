using System;

namespace _04.Fixing2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result;

            firstNumber = 30;
            secondNumber = 60;
            result = 0;

            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);

            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
            Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");

        }
    }
}
