using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extension.Sorting;

namespace Vishnu.Extensions
{
    /// <summary>
    /// Class responsible for performing Sorting.
    /// </summary>
    public class Algorithm : ISort
    {
        /// <summary>
        /// Interface to perform sorting on the input data
        /// </summary>
        public static ISort Sorting
        {
            get
            {
                return new Algorithm();
            }
        }
    }
}
