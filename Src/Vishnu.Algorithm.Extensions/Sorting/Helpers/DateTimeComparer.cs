using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    /// <summary>
    /// Date and time comparer
    /// </summary>
    public class DateTimeComparer : IComparer<DateTime>
    {
        /// <summary>
        /// Compare x with y.
        /// </summary>
        /// <param name="x">compare value</param>
        /// <param name="y">compare with</param>
        /// <returns>
        /// 1 if x > y
        /// -1 if x < y
        /// 0 if x == y
        /// </returns>
        public int Compare(DateTime x, DateTime y)
        {
            return DateTime.Compare(x, y);
        }
    }
}
