using System;
using System.Threading;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int hp = 100;
            int bitcoins = 0;

            string[] dungeons = Console.ReadLine().Split("|");
            bool isAlive = true;

            for (int i = 0; i < dungeons.Length; i++)
            {
                string[] tokens = dungeons[i].Split();

                string action = tokens[0];
                int value = int.Parse(tokens[1]);

                if (action == "potion")
                {
                    int prevHp = hp;
                    hp += value;

                    if (hp > 100)
                    {
                        value-= hp - 100;
                        hp = 100;
                    }
                    Console.WriteLine($"You healed for {value} hp.");
                    Console.WriteLine($"Current health: {hp} hp.");
                }
                else if (action == "chest")
                {
                    bitcoins += value;
                    Console.WriteLine($"You found {value} bitcoins.");
                }
                else
                {
                    hp -= value;

                    if (hp > 0)
                    {
                        Console.WriteLine($"You slayed {action}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {action}.");
                        Console.WriteLine($"Best room: {i+1}");
                        isAlive = false;
                        break;
                    }
                }
            }

            if (isAlive)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {hp}");
            }
        }
    }
}
