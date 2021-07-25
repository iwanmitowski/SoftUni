using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            int strength = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (strength != 0)
                {
                    if (text[i] == '>')
                    {
                        sb.Append(text[i]);
                        strength += int.Parse(text[i + 1].ToString());
                        continue;
                    }

                    strength--;
                    continue;
                }

                if (text[i] == '>')
                {
                    sb.Append(text[i]);
                    strength += int.Parse(text[i + 1].ToString());
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
