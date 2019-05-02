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
    public class CocktailSort<T> : ISortingAlgorithm<T>
    {
        private readonly IComparer<T> _comparer = null;

        /// <summary>
        /// Creates new instance of <see cref="BubbleSort{T}"/> class
        /// </summary>
        /// <param name="comparer"><see cref="IComparer{T}"/></param>
        public CocktailSort(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Sorts input in ascending order
        /// </summary>
        /// <param name="input">input data</param>
        public virtual void Sort(T[] input)
        {
            bool swapped = true;
            int start = 0;
            int end = input.Length;

            while (swapped == true)
            {

                // reset the swapped flag on entering the 
                // loop, because it might be true from a 
                // previous iteration. 
                swapped = false;

                // loop from bottom to top same as 
                // the bubble sort 
                for (int i = start; i < end - 1; ++i)
                {
                    if (_comparer.Compare(input[i], input[i+1]) > 0)
                    {
                        var temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                        swapped = true;
                    }
                }

                // if nothing moved, then array is sorted. 
                if (swapped == false)
                    break;

                // otherwise, reset the swapped flag so that it 
                // can be used in the next stage 
                swapped = false;

                // move the end point back by one, because 
                // item at the end is in its rightful spot 
                end = end - 1;

                // from top to bottom, doing the 
                // same comparison as in the previous stage 
                for (int i = end - 1; i >= start; i--)
                {
                    if (_comparer.Compare(input[i], input[i + 1]) > 0)
                    {
                        var temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                        swapped = true;
                    }
                }

                // increase the starting point, because 
                // the last stage would have moved the next 
                // smallest number to its rightful spot. 
                start = start + 1;
            }
        }
    }
}
