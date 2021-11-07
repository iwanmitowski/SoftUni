using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corp { get; private set; }

        private void ParseCorps(string corps)
        {
            var parsed = Enum.TryParse(corps, out Corps corp);

            if (!parsed)
            {
                throw new InvalidEnumArgumentException();
            }

            this.Corp = corp;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine($"Corps: {Corp}");

            return result.ToString().TrimEnd();
        }
    }
}
