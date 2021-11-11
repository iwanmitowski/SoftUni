using _03.Raiding.Factory;
using _03.Raiding.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var heroes = new List<BaseHero>();
            IHeroFactory heroFactory = new HeroFactory();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    var hero = heroFactory.CreateHero(type, name);
                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            int bossHp = int.Parse(Console.ReadLine());

            var heroDmg = heroes.Sum(x => x.Power);

            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));

            if (heroDmg >= bossHp)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
