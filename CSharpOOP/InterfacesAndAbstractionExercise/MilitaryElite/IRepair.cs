using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IRepair
    {
        public string PartName { get;}
        public int HoursWorked { get; }
    }
}
