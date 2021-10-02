using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int DateDiff(string date1, string date2)
        {
            var firstDate = DateTime.Parse(date1);
            var secondDate = DateTime.Parse(date2);

            var result = firstDate - secondDate;

            return Math.Abs(result.Days);
        }
    }
}
