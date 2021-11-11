using _03.Raiding.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03.Raiding.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            var heroType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToLower().StartsWith(type.ToLower()) && !x.IsAbstract)
                .FirstOrDefault();

            if (heroType == null)
            {
                throw new InvalidOperationException("Invalid hero!");
            }

            BaseHero hero = null;

            try
            {
                hero = (BaseHero)Activator.CreateInstance(heroType, name);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

            return hero;
        }
    }
}
