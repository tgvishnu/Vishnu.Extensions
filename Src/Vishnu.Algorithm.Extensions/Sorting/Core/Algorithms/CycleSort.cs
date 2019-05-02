using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// Cycle sort is an in-place sorting Algorithm, unstable sorting algorithm,
    /// a comparison sort that is theoretically optimal in terms of the total number of writes to the original array.
    /// It is optimal in terms of number of memory writes.It minimizes the number of memory writes to sort
    /// (Each value is either written zero times, if it’s already in its correct position, or written one time 
    /// to its correct position.)
    /// It is based on the idea that array to be sorted can be divided into cycles.Cycles can be visualized as a graph.
    /// We have n nodes and an edge directed from node i to node j if the element at i-th index must be present at j-th 
    /// index in the sorted array.
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public class CycleSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public CycleSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public virtual void Sort(T[] input)
        {
            int n = input.Length;
            // count number of memory writes 
            int writes = 0;
            // traverse array elements and  
            // put it to on the right place 
            for(int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
            {
                // initialize item as starting point
                var item = input[cycle_start];
                // Find position where we put the item.  
                // We basically count all smaller elements  
                // on right side of item. 
                int pos = cycle_start;
                for(int i= cycle_start + 1; i < n; i++)
                {
                    if(_comparer.Compare(input[i], item) < 1)
                    {
                        pos++;
                    }
                }

                // If item is already in correct position 
                if (pos == cycle_start)
                    continue;

                // ignore all duplicate elements
                while(item.Equals(input[pos]))
                {
                    pos = pos + 1;
                }

                // put the item to it's right position 
                if(pos != cycle_start)
                {
                    var temp = item;
                    item = input[pos];
                    input[pos] = temp;
                    writes++;
                }

                // Rotate rest of the cycle 
                while(pos != cycle_start)
                {
                    pos = cycle_start;
                    // Find position where we put the element 
                    for(int i= cycle_start + 1; i <n; i++)
                    {
                        if(_comparer.Compare(input[i], item) < 1)
                        {
                            pos += 1;
                        }
                    }

                    while (item.Equals(input[pos]))
                    {
                        pos += 1;
                    }

                    // put the item to it's right position
                    if (item.Equals(input[pos]) == false)
                    {
                        var temp = item;
                        item = input[pos];
                        input[pos] = temp;
                        writes++;
                    }
                }
            }
        }
    }
}
