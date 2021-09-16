using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    int currentTime = greenDuration;

                    while (currentTime > 0 && cars.Any())
                    {
                        string currentCar = cars.Dequeue();
                        int carLength = currentCar.Length;

                        currentTime -= carLength;

                        if (currentTime >= 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            if (currentTime + freeWindowDuration < 0)
                            {
                                int hitIndex = carLength - Math.Abs(currentTime + freeWindowDuration);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[hitIndex]}.");
                                Environment.Exit(0);
                            }

                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
