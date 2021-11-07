using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string GetName();
    }
}
