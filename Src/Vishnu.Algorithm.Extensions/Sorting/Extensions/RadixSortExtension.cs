using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Extension methods for Radix sort
    /// </summary>
    public static class RadixSortExtension
    {
        /// <summary>
        /// Sorts input in ascending order using Radix sort technique
        /// This techique currently supports only positive integer sorting
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseRadix(this ISort sort, int[] input)
        {
            var radix = new RadixSort(new IntegerComparer());
            radix.Sort(input);
        }

        /// <summary>
        /// Sorts input in ascending order using Radix sort technique
        /// This techique currently supports only positive integer sorting
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseRadix(this ISort sort, int[] input, IComparer<int> comparer)
        {
            var radix = new RadixSort(comparer);
            radix.Sort(input);
        }
    }
}
