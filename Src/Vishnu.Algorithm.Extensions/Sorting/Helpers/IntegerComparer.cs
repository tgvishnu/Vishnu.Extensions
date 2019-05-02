using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    /// <summary>
    /// Integer value comparer
    /// </summary>
    public class IntegerComparer : IComparer<int>
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
        public int Compare(int x, int y)
        {
            if(x > y)
            {
                return 1;
            }

            if(x == y)
            {
                return 0;
            }

            return -1;
        }
    }
}
