using System;

namespace _05.ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = { "4", "4.5", "4.qweqweq", "", "321361544164416454162446124546210" };

            foreach (var value in values)
            {
                try
                {
                    var result = Math.Pow(System.Convert.ToDouble(value), 69);

                    if (double.IsNegativeInfinity(result) || 
                        double.IsInfinity(result))
                    {
                        throw new OverflowException();
                    }

                    Console.WriteLine(result);
                }
                catch (OverflowException ofe)
                {
                    Console.WriteLine(ofe.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
        }
    }
}
