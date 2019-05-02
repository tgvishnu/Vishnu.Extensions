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
    public abstract class QuickSort<T> : ISortingAlgorithm<T>
    {
        protected readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="InsertionSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public QuickSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input</param>
        public abstract void Sort(T[] input);

        /// <summary>
        /// </summary>
        /// <param name="input">input content</param>
        /// <param name="low">starting index</param>
        /// <param name="high">ending index</param>
        protected virtual void Sort(T[] input, int low, int high)
        {
            if (low < high)
            {
                /* p is partitioning index, input[p] is  now at right place */
                int p = Partition(input, low, high);
                // Recursively sort elements before 
                // partition and after partition 
                Sort(input, low, p - 1);
                Sort(input, p + 1, high);
            }
        }

        /// <summary>
        /// This function takes last element as pivot, places the pivot element at its correct position in sorted array, 
        /// and places all smaller(smaller than pivot) to left of pivot and all greater elements to right of pivot
        /// </summary>
        /// <param name="input">input content</param>
        /// <param name="low">starting index</param>
        /// <param name="high">ending index</param>
        /// <returns>partition index</returns>
        protected virtual int Partition(T[] input, int low, int high)
        {
            T pivot = input[high];
            // index of smaller element
            int i = (low - 1);
            for(int j = low; j< high; j++)
            {
                // If current element is smaller  
                // than or equal to pivot 
                if(_comparer.Compare(input[j], pivot) <= 0)
                {
                    i++;
                    var temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                }
            }

            var temp1 = input[i + 1];
            input[i + 1] = input[high];
            input[high] = temp1;
            return i + 1;
        }
    }
}
