using System;
using System.Text;

namespace _05.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num==0)
                {
                    sb.Append(" ");
                    continue;
                }

                int mainDigit = num % 10;

                int offset = (mainDigit - 2) * 3;

                if (mainDigit==8||mainDigit==9)
                {
                    offset++;
                }

                int letterIndex = (offset + num.ToString().Length - 1);

                sb.Append((char)('a'+letterIndex));
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
