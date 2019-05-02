using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Extension methods for Insertion sort
    /// </summary>
    public static class InsertionSortExtension
    {
        /// <summary>
        /// Sorts input in ascending order using Insertion sort technique
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static T[] UseInsertion<T>(this ISort sort, T[] input, IComparer<T> comparer)
        {
            return sort.Sort<T>(SortingTypes.Insertion, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Insertion sort technique
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static T[] UseInsertion<T>(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, T[] input, IComparer<T> comparer)
        {
            return sort.Sort<T>(sortingAlgorithmFactory, SortingTypes.Insertion, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Insertion sort technique
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseInsertion(this ISort sort, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(SortingTypes.Insertion, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Insertion sort technique
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseInsertion(this ISort sort, ISortingAlgorithmFactory sortingAlgorithmFactory, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(sortingAlgorithmFactory, SortingTypes.Insertion, input, comparer);
        }
    }
}
