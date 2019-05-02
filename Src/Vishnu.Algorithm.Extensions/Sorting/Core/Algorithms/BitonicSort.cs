using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// A sequence is called Bitonic if it is first increasing, then decreasing.
    /// In other words, an array arr[0..n-i] is Bitonic if there exists an index i where 0<=i<=n-1 such that
    /// A sequence, sorted in increasing order is considered Bitonic with the decreasing part as empty. Similarly, decreasing order sequence is considered Bitonic with the increasing part as empty.
    /// A rotation of Bitonic Sequence is also bitonic.
    /// </summary>
    /// <typeparam name="T">Type of input</typeparam>
    public class BitonicSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="HeapSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public BitonicSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input</param>
        public virtual void Sort(T[] input)
        {
            int n = input.Length;
            this.BiotonicSort(input, 0, n, 1);
        }

        /// <summary>
        /// It recursively sorts a bitonic sequence in ascending order,  
        /// if dir = 1, and in descending order otherwise(means dir = 0).  
        /// The sequence to be sorted starts at index position low,
        /// the parameter cnt is the number of elements to be sorted
        /// </summary>
        /// <param name="input">input</param>
        /// <param name="low">initial value</param>
        /// <param name="cnt">total count</param>
        /// <param name="dir">direction</param>
        private void BitonicMerger(T[] input, int low, int cnt, int dir)
        {
            if(cnt > 1)
            {
                int k = cnt / 2;
                for(int i= low; i < low + k; i ++)
                {
                    int x = 0;
                    if(_comparer.Compare(input[i], input[i + k]) > 0)
                    {
                        x = 1;
                    }

                    if(dir == x)
                    {
                        var temp = input[i];
                        input[i] = input[i + k];
                        input[i + k] = temp;
                    }
                }

                this.BitonicMerger(input, low, k, dir);
                this.BitonicMerger(input, low + k, k, dir);
            }
        }

        /// <summary>
        /// Sort input
        /// </summary>
        /// <param name="input">input</param>
        /// <param name="low">index</param>
        /// <param name="cnt">items</param>
        /// <param name="dir">direction</param>
        private void BiotonicSort(T[] input, int low, int cnt, int dir)
        {
            if(cnt > 1)
            {
                int k = cnt / 2;
                // sort in ascending order dir = 1
                this.BiotonicSort(input, low, k, 1);
                // sort in descending order dir = 0
                this.BiotonicSort(input, low + k, k, 0);
                this.BitonicMerger(input, low, cnt, dir);
            }
        }
    }
}
