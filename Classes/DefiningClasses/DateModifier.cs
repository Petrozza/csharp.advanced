using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class DateModifier
    {
        public int GetDateDifferences(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            double result = Math.Abs((startDate - endDate).TotalDays);
            
            return (int)result;
        }
    }
}
