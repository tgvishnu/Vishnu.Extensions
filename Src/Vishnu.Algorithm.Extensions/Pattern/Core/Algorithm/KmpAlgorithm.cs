using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// whenever we detect a mismatch (after some matches),
    /// we already know some of the characters in the text of the next window.
    /// We take advantage of this information to avoid matching the characters
    /// that we know will anyway match
    /// </summary>
    public class KmpAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;

        /// <summary>
        /// Creates new instance of <see cref="KmpAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public KmpAlgorithm(string text, string pattern)
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
            // create lps[] that will hold the longest 
            // prefix suffix values for pattern 
            int[] lps = new int[m];
            int j = 0;
            this.ComputeLpsArray(_pattern, m, lps);
            int i = 0;
            while(i < n)
            {
                if(_pattern[j] == _text[i])
                {
                    j++;
                    i++;
                }
                if(j == m)
                {
                    indexes.Add(i - j);
                    j = lps[j - 1];
                }
                else if(i<n && _pattern[j] != _text[i])
                {
                    if(j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }

            return indexes;
        }

        private void ComputeLpsArray(string pattern, int m, int[] lps)
        {
            // length of the previous longest prefix suffix 
            int len = 0;
            int i = 1;
            lps[0] = 0;

            // the loop calculates lps[i] for i = 1 to M-1 
            while(i < m)
            {
                if(pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if(len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }
    }
}
