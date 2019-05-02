using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Extension methods for Merge sort
    /// </summary>
    public static class MergeSortingExtension
    {
        /// <summary>
        /// Sorts input in ascending order using Merge sort technique
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static T[] UseMerge<T>(this ISort sort, T[] input, IComparer<T> comparer)
        {
            return sort.Sort<T>(SortingTypes.Merge, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Merge sort technique
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static T[] UseMerge<T>(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, T[] input, IComparer<T> comparer)
        {
            return sort.Sort<T>(sortingAlgorithmFactory, SortingTypes.Merge, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Merge sort technique
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseMerge(this ISort sort, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(SortingTypes.Merge, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Merge sort technique
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseMerge(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(sortingAlgorithmFactory, SortingTypes.Merge, input, comparer);
        }
    }
}
