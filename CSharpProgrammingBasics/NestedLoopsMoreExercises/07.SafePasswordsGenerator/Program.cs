using System;

namespace _07.SafePasswordsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int A = 35;
            int B = 64;

            int maxPasswords = int.Parse(Console.ReadLine());
            
            for (int x = 1; x <=a; x++)
            {
                for (int y = 1; y <=b; y++)
                {
                    Console.Write($"{(char)A}{(char)B}{x}{y}{(char)B}{(char)A}|");
                    A++;
                    B++;
                    if (A > 55)
                    {
                        A = 35;
                    }
                    if (B > 96)
                    {
                        B = 64;
                    }

                    maxPasswords--;

                    if (maxPasswords==0)
                    {
                        Environment.Exit(0);
                    }
                }
            }




        }
    }
}
