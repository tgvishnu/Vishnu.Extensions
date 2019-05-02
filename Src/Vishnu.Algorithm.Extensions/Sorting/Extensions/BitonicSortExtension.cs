using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Extension methods for Bitonic sort
    /// </summary>
    public static class BitonicSortExtension
    {
        /// <summary>
        /// Sorts input in ascending order using Bitonic sort technique.
        /// This will work only if the input size is power of 2
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseBitonic<T>(this ISort sort, T[] input, IComparer<T> comparer)
        {
            sort.Sort<T>(SortingTypes.Bitonic, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Bitonic sort technique
        /// This will work only if the input size is power of 2
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseBitonic<T>(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, T[] input, IComparer<T> comparer)
        {
            sort.Sort<T>(sortingAlgorithmFactory, SortingTypes.Bitonic, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Bitonic sort technique
        /// This will work only if the input size is power of 2
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseBitonic(this ISort sort, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(SortingTypes.Bitonic, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Bitonic sort technique
        /// This will work only if the input size is power of 2
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseBitonic(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(sortingAlgorithmFactory, SortingTypes.Bitonic, input, comparer);
        }
    }
}
