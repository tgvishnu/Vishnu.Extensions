using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Sorting.Core;
using Vishnu.Extensions.Sorting.Helpers;

namespace Vishnu.Extensions.Sorting
{
    /// <summary>
    /// Extension methods for bubble sort
    /// </summary>
    public static class BubbleSortExtension
    {
        /// <summary>
        /// Sorts input in ascending order using Bubble sort technique
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseBubble<T>(this ISorting sort, T[] input, IComparer<T> comparer)
        {
            sort.Sort<T>(SortingTypes.Bubble, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Bubble sort technique
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        public static void UseBubble<T>(this ISorting sort, ISortingAlgorithmFactory sortingAlgorithmFactory, T[] input, IComparer<T> comparer)
        {
            sort.Sort<T>(sortingAlgorithmFactory, SortingTypes.Bubble, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Bubble sort technique
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseBubble(this ISorting sort, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(SortingTypes.Bubble, input, comparer);
        }

        /// <summary>
        /// Sorts input in ascending order using Bubble sort technique
        /// </summary>
        /// <param name="sort">ISort</param>
        /// <param name="sortingAlgorithmFactory">Sorting algorithm factory</param>
        /// <param name="input">input data</param>
        /// <param name="comparer">Comparer must returns '1' if the first element is greater than next</param>
        /// <returns>The ascending ordered content</returns>
        public static string UseBubble(this ISorting sort, ISortingAlgorithmFactory sortingAlgorithmFactory, string input, IComparer<char> comparer = null)
        {
            return sort.Sort(sortingAlgorithmFactory, SortingTypes.Bubble, input, comparer);
        }
    }
}
