using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string result = ReadFromConsole(type);

            Console.WriteLine(result);
        }

        private static string ReadFromConsole(string type)
        {
            string result = string.Empty;

            switch (type)
            {
                case "int":
                    result = (int.Parse(Console.ReadLine()) * 2).ToString();
                    break;
                case "real":
                    result = $"{double.Parse(Console.ReadLine())*1.5:f2}";
                    break;
                default:
                    result=$"${Console.ReadLine()}$";
                    break;

            }

            return result;
        }
    }
}
