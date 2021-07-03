using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03.ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateship = Console.ReadLine().Split(">").Select(int.Parse).ToList();
            List<int> battleship = Console.ReadLine().Split(">").Select(int.Parse).ToList();

            int maxHp = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input!= "Retire")
            {
                string[] tokens = input.Split();
                
                string command = tokens[0];
                int index = 0;

                if (command!="Status")
                {
                    index = int.Parse(tokens[1]);
                }


                switch (command)
                {
                    case "Fire":
                        if (!IsValidIndex(index, battleship.Count))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        int dmg = int.Parse(tokens[2]);
                        battleship[index] -= dmg;

                        if (battleship[index]<=0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            Environment.Exit(0);
                        }
                        break;

                    case "Defend":
                        int endIndex = int.Parse(tokens[2]);

                        if (!IsValidIndex(index, pirateship.Count) ||
                            !IsValidIndex(endIndex, pirateship.Count))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        int dmgD = int.Parse(tokens[3]);

                        for (int i = index; i <= endIndex; i++)
                        {
                            pirateship[i] -= dmgD;

                            if (pirateship[i]<=0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                Environment.Exit(0);
                            }
                        }
                        break;

                    case "Repair":
                        if (!IsValidIndex(index, pirateship.Count))
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        int hp = int.Parse(tokens[2]);
                        pirateship[index] += hp;

                        if (pirateship[index]>maxHp)
                        {
                            pirateship[index] = maxHp;
                        }
                        break;

                    case "Status":
                        int count = pirateship.Where(x => x < maxHp * 0.2).Count();
                        Console.WriteLine($"{count} sections need repair.");
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateship.Sum()}");
            Console.WriteLine($"Warship status: {battleship.Sum()}");

        }

        private static bool IsValidIndex(int index, int count)
        {
            return index >= 0 && index < count;
        }
    }
}
