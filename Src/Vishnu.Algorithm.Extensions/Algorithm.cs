using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Pattern;
using Vishnu.Extensions.Sorting;

namespace Vishnu.Extensions
{
    /// <summary>
    /// Class responsible for performing Sorting.
    /// </summary>
    public class Algorithm : ISorting, IPattern
    {
        /// <summary>
        /// Interface to perform sorting on the input data
        /// </summary>
        public static ISorting Sorting
        {
            get
            {
                return new Algorithm();
            }
        }

        /// <summary>
        /// Interface to perform pattern searching on the input
        /// </summary>
        public static IPattern PatternSearch
        {
            get
            {
                return new Algorithm();
            }
        }
    }
}
