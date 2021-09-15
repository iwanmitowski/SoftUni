using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> boxes = new Stack<int>(clothes);

            int racks = 1;
            int capacity = int.Parse(Console.ReadLine());
            int currentCapacity = 0;

            while (boxes.Any())
            {
                int currentClothes = boxes.Pop();

                if (currentCapacity + currentClothes == capacity)
                {
                    if (boxes.Any())
                    {
                        racks++;
                    }

                    currentCapacity = 0;
                }
                else if (currentCapacity + currentClothes > capacity)
                {
                    racks++;
                    currentCapacity = currentClothes;
                }
                else
                {
                    currentCapacity += currentClothes;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
