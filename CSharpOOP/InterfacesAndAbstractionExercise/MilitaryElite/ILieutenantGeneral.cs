using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
        public IEnumerable<IPrivate> Privates { get;}
    }
}
