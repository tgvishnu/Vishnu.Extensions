using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// The algorithm works by selecting the smallest unsorted item
    /// and then swapping it with the item in the next position to be filled.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SelectionSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="SelectionSort{T}"/> class.
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public SelectionSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">content</param>
        public virtual void Sort(T[] input)
        {
            int min = 0;
            for(int ii=0; ii<input.Length; ii++)
            {
                min = ii;
                for(int jj= ii+1; jj< input.Length; jj++)
                {
                    if(_comparer.Compare(input[jj], input[min]) < 0)
                    {
                        min = jj;
                    }
                }

                T temp = input[ii];
                input[ii] = input[min];
                input[min] = temp;
            }
        }
    }
}
