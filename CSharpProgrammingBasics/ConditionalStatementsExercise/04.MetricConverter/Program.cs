using System;

namespace _04.MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string inputMetricUnit = Console.ReadLine();
            string outputMetricUnit = Console.ReadLine();

            if (inputMetricUnit == "mm" && outputMetricUnit == "cm")
            {
               number /= 10;
            }
            else if (inputMetricUnit=="mm"&&outputMetricUnit=="m")
            {
                number /= 1000;
            }
            else if (inputMetricUnit=="cm"&&outputMetricUnit=="mm")
            {
                number *= 10;
            }
            else if (inputMetricUnit == "cm" && outputMetricUnit == "m")
            {
                number /= 100;
            }
            else if (inputMetricUnit == "m" && outputMetricUnit == "mm")
            {
                number *= 1000;
            }
            else if (inputMetricUnit == "m" && outputMetricUnit == "cm")
            {
                number *= 100;
            }

            Console.WriteLine($"{number:f3}");
        }
    }
}
