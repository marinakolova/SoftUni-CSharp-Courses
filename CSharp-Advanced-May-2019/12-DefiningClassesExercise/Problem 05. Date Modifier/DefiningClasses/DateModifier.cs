using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int CalcDaysBetweenDates(string firstDate, string secondDate)
        {
            var firstDateDetails = firstDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();            

            var secondDateDetails = secondDate
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var startDate = new DateTime(firstDateDetails[0], firstDateDetails[1], firstDateDetails[2]);
            var endDate = new DateTime(secondDateDetails[0], secondDateDetails[1], secondDateDetails[2]);

            int daysBetweenDates = (endDate.Date - startDate.Date).Days;
            return daysBetweenDates;
        }
    }
}
