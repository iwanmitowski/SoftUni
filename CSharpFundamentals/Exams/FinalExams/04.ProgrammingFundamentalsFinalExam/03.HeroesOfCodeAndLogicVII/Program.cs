using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroHPMP = new Dictionary<string,int[]> ();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string hero = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);

                heroHPMP.Add(hero, new int[] { hp, mp });
            }

            string input = Console.ReadLine();

            
            while (input!="End")
            {
                string[] tokens = input.Split(" - ");

                string command = tokens[0];
                string hero = tokens[1];

                switch (command)
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(tokens[2]);
                        string spell = tokens[3];

                        int heroMP = heroHPMP[hero][1];

                        if (heroMP>=mpNeeded)
                        {
                            heroHPMP[hero][1] -= mpNeeded;
                            Console.WriteLine($"{hero} has successfully cast {spell} and now has {heroHPMP[hero][1]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{hero} does not have enough MP to cast {spell}!");
                        }
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];

                        heroHPMP[hero][0] -= damage;

                        if (heroHPMP[hero][0]>0)
                        {
                            Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {heroHPMP[hero][0]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{hero} has been killed by {attacker}!");
                        }
                        break;
                    case "Recharge":
                        int amount = int.Parse(tokens[2]);
                        int heroMana = heroHPMP[hero][1];
                        heroHPMP[hero][1] += amount;

                        if (heroHPMP[hero][1]>200)
                        {
                            heroHPMP[hero][1] = 200;
                            amount = heroHPMP[hero][1] - heroMana;
                        }

                        Console.WriteLine($"{hero} recharged for {amount} MP!");
                        break;
                    case "Heal":
                        amount = int.Parse(tokens[2]);
                        int heroHP = heroHPMP[hero][0];
                        heroHPMP[hero][0] += amount;

                        if (heroHPMP[hero][0] > 100)
                        {
                            heroHPMP[hero][0] = 100;
                            amount = heroHPMP[hero][0] - heroHP;
                        }

                        Console.WriteLine($"{hero} healed for {amount} HP!");
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach ((string hero, int[] hpMP) in heroHPMP.Where(x => x.Value[0] > 0).OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            {
                Console.WriteLine(hero);
                Console.WriteLine($"  HP: {hpMP[0]}");
                Console.WriteLine($"  MP: {hpMP[1]}");
            }
        }
    }
}
