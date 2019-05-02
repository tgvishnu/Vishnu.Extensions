using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// The algorithm works by comparing each item in the list with the item next to it, 
    /// and swapping them if required. In other words, 
    /// the largest element has bubbled to the top of the array. The algorithm repeats this 
    /// process until it makes a pass all the way through the list without swapping any items.
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class BubbleSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public BubbleSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public virtual void Sort(T[] input)
        {
            for(int ii = (input.Length - 1); ii >= 0; ii--)
            {
                for(int jj = 1; jj <= ii; jj++)
                {
                    if(_comparer.Compare(input[jj - 1], input[jj]) > 0 )
                    {
                        var temp = input[jj - 1];
                        input[jj - 1] = input[jj];
                        input[jj] = temp;
                    }
                }
            }
        }
    }
}
