using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// The bitap algorithm 
    /// (also known as the shift-or, shift-and or Baeza-Yates–Gonnet algorithm) is an approximate string matching algorithm.
    /// The algorithm tells whether a given text contains a substring which is "approximately equal" to a given pattern, 
    /// where approximate equality is defined in terms of Levenshtein distance — if the substring and pattern are 
    /// within a given distance k of each other, then the algorithm considers them equal. The algorithm begins by
    /// precomputing a set of bitmasks containing one bit for each element of the pattern
    /// </summary>
    public class BitapAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;
        private const int MAX = 256;

        /// <summary>
        /// Creates new instance of <see cref="BitapAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public BitapAlgorithm(string text, string pattern)
        {
            _text = text;
            _pattern = pattern;
        }

        /// <summary>
        /// Searches for specific pattern
        /// </summary>
        /// <returns></returns>
        public IList<int> Search()
        {
            List<int> indexes = new List<int>();
            int m = _pattern.Length;
            int r = 0;
            int[] patternMask = new int[128];
            int i;
            if (string.IsNullOrEmpty(_pattern))
            {
                return indexes;
            }

            if(m > 31)
            {
                return indexes;
            }

            for (i = 0; i <= 127; ++i)
            {
                patternMask[i] = ~0;
            }

            for (i = 0; i < m; ++i)
            {
                patternMask[_pattern[i]] &= ~(1 << i);
            }

            for (i = 0; i < _text.Length; ++i)
            {
                r |= patternMask[_text[i]];
                r <<= 1;

                if (0 == (r & (1 << m)))
                {
                    indexes.Add( (i - m) + 1);
                }
            }

            indexes.RemoveAll(e => e < 0);
            return indexes;
        }
    }
}
