using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    /// <summary>
    /// String length comparer
    /// </summary>
    public class StringLengthComparer : IComparer<string>
    {
        private IComparer<int> _comparer;

        /// <summary>
        /// Creates new instance of <see cref="StringLengthComparer"/> class.
        /// </summary>
        /// <param name="lengthComparer"><see cref="IComparer{T}"/></param>
        public StringLengthComparer(IComparer<int> lengthComparer = null)
        {
            if(lengthComparer == null)
            {
                _comparer = new IntegerComparer();
            }
            else
            {
                _comparer = lengthComparer;
            }
            
        }

        /// <summary>
        /// Compare x with y.
        /// </summary>
        /// <param name="x">compare value</param>
        /// <param name="y">compare with</param>
        /// <returns>
        /// 1 if x > y
        /// -1 if x < y
        /// 0 if x == y
        /// </returns>
        public int Compare(string x, string y)
        {
            int xLength = 0;
            int yLength = 0;
            if(!string.IsNullOrEmpty(x))
            {
                xLength = x.Length;
            }

            if (!string.IsNullOrEmpty(y))
            {
                yLength = y.Length;
            }

            return _comparer.Compare(xLength, yLength);
        }
    }
}
