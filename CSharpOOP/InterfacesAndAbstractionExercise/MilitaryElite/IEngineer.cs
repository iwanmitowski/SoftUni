using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IEngineer
    {
        public IEnumerable<IRepair> Repairs { get; }
    }
}
