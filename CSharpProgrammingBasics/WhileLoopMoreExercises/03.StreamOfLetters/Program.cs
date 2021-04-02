using System;
using System.Text;

namespace _03.StreamOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int c = 0;
            int o = 0;
            int n = 0;

            StringBuilder sbResult = new StringBuilder();

            string letters = Console.ReadLine();

            while (letters != "End")
            {
                bool isInvalid = false;
                if (!char.IsLetter(char.Parse(letters)))
                {
                    isInvalid = true;
                }
                else if (letters == "c" && c == 0)
                {
                    c++;
                    isInvalid = true;
                }
                else if (letters == "o" && o == 0)
                {
                    o++;
                    isInvalid = true;
                }
                else if (letters == "n" && n == 0)
                {
                    n++;
                    isInvalid = true;
                }

                if (c==1&&o==1&&n==1)
                {
                    sb.Append(" ");

                    c--;
                    o--;
                    n--; 

                    sbResult.Append(sb.ToString());
                    sb.Clear();
                    
                }

                if (isInvalid)
                {
                    letters = Console.ReadLine();
                    continue;
                }

                sb.Append(letters);


                letters = Console.ReadLine();
            }
            Console.Write(sbResult.ToString());

        }
    }
}
