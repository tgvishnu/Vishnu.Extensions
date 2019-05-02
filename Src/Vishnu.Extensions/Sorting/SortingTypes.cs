using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extension.Sorting
{
    /// <summary>
    /// Defines various sorting types
    /// </summary>
    public enum SortingTypes
    {
        /// <summary>
        /// Bubble sort
        /// </summary>
        Bubble,

        /// <summary>
        /// Selection sort
        /// </summary>
        Selection,

        /// <summary>
        /// Insertion sort
        /// </summary>
        Insertion,

        /// <summary>
        /// Merge sort
        /// </summary>
        Merge,

        /// <summary>
        /// Quick sort (Last element as pivot)
        /// </summary>
        Quick_LastPivot
    }
}
