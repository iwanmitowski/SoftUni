using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Factory.Contracts
{
    public interface IHeroFactory
    {
        BaseHero CreateHero(string type, string name);
    }
}
