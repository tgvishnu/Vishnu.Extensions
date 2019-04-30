using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Core
{
    /// <summary>
    /// Defines methods and properties for Sorting algorithms
    /// </summary>
    /// <typeparam name="T">type of data</typeparam>
    public interface ISortingAlgorithm<T>
    {
        /// <summary>
        /// Sorts input in Ascending order
        /// </summary>
        /// <param name="input">content</param>
        void Sort(T[] input);
    }
}
