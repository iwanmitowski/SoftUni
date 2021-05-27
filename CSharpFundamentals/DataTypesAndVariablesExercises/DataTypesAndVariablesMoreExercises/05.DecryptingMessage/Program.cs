using System;
using System.Text;

namespace _05.DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                sb.Append((char)(char.Parse(Console.ReadLine()) + key));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
