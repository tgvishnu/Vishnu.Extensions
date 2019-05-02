using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Extension methods for Counting sort
    /// </summary>
    public static class CountingSortExtension
    {
        /// <summary>
        /// Sorts input in ascending order using Counting sort technique
        /// This techique currently supports only positive integer sorting
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="propertyComparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseCounting<T>(this ISort sort, T[] input, Func<T, int> propertyComparer)
        {
            var countSort = new CountingSort<T>(propertyComparer);
            countSort.Sort(input);
        }

        /// <summary>
        /// Sorts input in ascending order using Counting sort technique
        /// This techique currently supports only positive integer sorting.
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseCounting(this ISort sort, string input)
        {
            var countSort = new CountingSort<char>(x => { return (int)x; });
            var charArray = input.ToCharArray();
            countSort.Sort(charArray);
            return new string(charArray);
        }
    }
}
