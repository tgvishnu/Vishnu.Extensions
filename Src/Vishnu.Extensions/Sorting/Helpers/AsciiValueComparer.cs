using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Sorting.Helpers
{
    /// <summary>
    /// Ascii value comparer 
    /// </summary>
    public class AsciiValueComparer : IComparer<char>
    {
        private IComparer<int> _comparer;

        /// <summary>
        /// Creates new instance of <see cref="AsciiValueComparer"/> class
        /// </summary>
        /// <param name="lengthComparer"><see cref="IComparer{T}"/></param>
        public AsciiValueComparer(IComparer<int> lengthComparer = null)
        {
            if (lengthComparer == null)
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
        public int Compare(char x, char y)
        {
            int asciiX = (int)x;
            int asciiY = (int)y;
            return _comparer.Compare(asciiX, asciiY);
        }
    }
}
