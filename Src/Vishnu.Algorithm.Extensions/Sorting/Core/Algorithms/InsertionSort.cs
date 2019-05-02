using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// Insertion sort is a simple sorting algorithm that works the way we sort playing cards in our hands.
    /// Algorithm
    /// Sort an arr[] of size n
    /// insertionSort(arr, n)
    /// Loop from i = 1 to n-1.
    /// ……a) Pick element arr[i] and insert it into sorted sequence arr[0…i - 1]
    /// </summary>
    /// <typeparam name="T">Type of input</typeparam>
    public class InsertionSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="InsertionSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public InsertionSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input</param>
        public virtual void Sort(T[] input)
        {
            for (int ii = 1; ii < input.Length; ii++)
            {
                var key = input[ii];
                var jj = ii - 1;
                while (jj >= 0 && (_comparer.Compare(input[jj], key) > 0))
                {
                    input[jj + 1] = input[jj];
                    jj = jj - 1;
                }

                input[jj + 1] = key;
            }
        }
    }
}
