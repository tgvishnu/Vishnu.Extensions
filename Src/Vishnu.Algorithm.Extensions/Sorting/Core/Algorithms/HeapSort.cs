using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    ///  1. Build a max heap from the input data.
    /// 2. At this point, the largest item is stored at the root of the heap.
    /// Replace it with the last item of the heap followed by reducing the size of heap by 1.
    /// Finally, heapify the root of tree.
    /// 3. Repeat above steps while size of heap is greater than 1.
    /// </summary>
    /// <typeparam name="T">Type of input</typeparam>
    public class HeapSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="InsertionSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public HeapSort(IComparer<T> comparer)
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
            // build heap
            for(int i= n/2-1; i>=0; i--)
            {
                this.Heapify(input, n, i);
            }

            // one by one extract an element from heap
            for(int i=n-1; i>=0; i--)
            {
                var temp = input[0];
                input[0] = input[i];
                input[i] = temp;
                // call max hepify on the reduced map.
                this.Heapify(input, i, 0);
            }
        }

        /// <summary>
        /// To heapify a subtree rooted with node i which is an index in input[]. n is size of heap 
        /// </summary>
        /// <param name="input">input</param>
        /// <param name="n">heap size</param>
        /// <param name="i">input index</param>
        private void Heapify(T[] input, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1; // left
            int r = 2 * i + 2; // right
            // if left child is larger than root
            if(l < n && (_comparer.Compare(input[l], input[largest]) > 0))
            {
                largest = l;
            }
            // if right child is larger than largest so far
            if(r < n && (_comparer.Compare(input[r], input[largest]) > 0))
            {
                largest = r;
            }
            // if largest is not root
            if(largest != i)
            {
                var temp = input[i];
                input[i] = input[largest];
                input[largest] = temp;

                // recursively hepify the affected sub-tree
                this.Heapify(input, n, largest);
            }
        }
    }
}
