using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _07.TruckTour
{
    class Pump
    {
        public long Petrol { get; set; }
        public int DistanceToNext { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<Pump> pumps = new Queue<Pump>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                pumps.Enqueue(new Pump()
                {
                    Petrol = long.Parse(input[0]),
                    DistanceToNext = int.Parse(input[1]),
                });
            }

            int index = -1;

            for (int i = 0; i < n; i++)
            {
                bool isLooped = true;
                long currentFuel = 0;

                for (int j = 0; j < n; j++)
                {
                    var currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    currentFuel += currentPump.Petrol;

                    if (currentFuel < currentPump.DistanceToNext)
                    {
                        isLooped = false;
                    }
                    else
                    {
                        currentFuel -= currentPump.DistanceToNext;
                    }
                }

                if (isLooped)
                {
                    index = i;
                    break;
                }

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
