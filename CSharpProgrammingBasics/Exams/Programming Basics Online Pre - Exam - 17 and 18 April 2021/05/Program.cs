using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = 1;
            int start = 5364;
            int goal = 8848;

            string input = Console.ReadLine();

            while (input!="END")
            {
                if (input == "Yes")
                {
                    days++;
                    if (days > 5)
                    {
                        break;
                    }
                }

                int meters = int.Parse(Console.ReadLine());
                

                start += meters;

                if (start >= goal)
                {
                    break;
                }
                  
                
                
                input = Console.ReadLine();
            }

            if (start>=goal)
            {
                Console.WriteLine($"Goal reached for {days} days!");

            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(start);
            }
        }
    }
}
