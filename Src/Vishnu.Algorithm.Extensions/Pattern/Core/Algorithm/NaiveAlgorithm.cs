using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// Slide the pattern over text one by one and check for a match. 
    /// If a match is found, then slides by 1 again to check for subsequent matches.
    /// </summary>
    public class NaiveAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;

        /// <summary>
        /// Creates new instance of <see cref="NaiveAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public NaiveAlgorithm(string text, string pattern)
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
            int n = _text.Length;
            int m = _pattern.Length;

            /* A loop to slide pat one by one */
            for (int i=0; i<n-m;i++)
            {
                /* For current index i, check for pattern  match */
                int j = 0;
                for (j=0;j<m;j++)
                {
                    if(_text[i + j] != _pattern[j])
                    {
                        break;
                    }
                }

                // if pat[0...M-1] = txt[i, i+1, ...i+M-1] 
                if (j == m)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }
    }
}
