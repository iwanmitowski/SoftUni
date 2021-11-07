using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando
    {
        public IEnumerable<IMission> Missions { get; }
    }
}
