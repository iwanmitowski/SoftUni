using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> barrel = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            int shotBullets = 0;

            while (locks.Any() && barrel.Any())
            {
                int currentBullet = barrel.Pop();

                

                int currentLock = locks.Peek();
                shotBullets++;

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (shotBullets % barrelSize == 0 && barrel.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (barrel.Count >= 0 && !locks.Any())
            {
                int money = intelligence - (bulletPrice * shotBullets);
                Console.WriteLine($"{barrel.Count} bullets left. Earned ${money}");
            }
            else if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
            }
        }
    }
}
