using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// It picks an element as pivot and partitions the given array around the picked pivot. 
    /// he key process in quickSort is partition(). Target of partitions is, given an array and an element x
    /// of array as pivot, put x at its correct position in sorted array and put all smaller elements (smaller than x) before x,
    /// and put all greater elements (greater than x) after x. All this should be done in linear time.
    /// </summary>
    /// <typeparam name="T">Type of input</typeparam>
    public class QuickSortLastPivot<T> : QuickSort<T>
    {

        /// <summary>
        /// Creates new instance of <see cref="QuickSortLastPivot{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public QuickSortLastPivot(IComparer<T> comparer)
            :base(comparer)
        {
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input</param>
        public override void Sort(T[] input)
        {
            base.Sort(input, 0, input.Length - 1);
        }
    }
}
