using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.DateTimeType
{
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// Get Oridinal suffix for Day.
        /// </summary>
        /// <param name="dateTime">System.DateTime</param>
        /// <returns>Ordinal Day in string format</returns>
        public static string OrdinalSuffix(this System.DateTime dateTime)
        {
            int day = dateTime.Day;
            if (day % 100 >= 11 && day % 100 <= 13)
            {
                return string.Concat(day, "th");
            }

            switch (day % 10)
            {
                case 1:
                    return string.Concat(day, "st");
                case 2:
                    return string.Concat(day, "nd");
                case 3:
                    return string.Concat(day, "rd");
                default:
                    return string.Concat(day, "th");
            }
        }

        /// <summary>
        /// Check if date falls between the range of dates
        /// </summary>
        /// <param name="self">Current date</param>
        /// <param name="begin">Begin date</param>
        /// <param name="end">End date</param>
        /// <returns><c>true</c> if lies between begin and end else <c>false.</c></returns>
        public static bool Between(this DateTime self, DateTime begin, DateTime end)
        {
            return self.Ticks >= begin.Ticks && self.Ticks <= end.Ticks;
        }

        /// <summary>
        /// Calcuate Age 
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns>age</returns>
        public static int Age(this DateTime dateTime)
        {
            var age = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now < dateTime.AddYears(age))
                age--;
            return age;
        }
    }
}
