using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// he Boyer-Moore algorithm searches for occurrences of P in T by performing explicit character comparisons 
    /// at different alignments. Instead of a brute-force search of all alignments (of which there are {\displaystyle m-n+1} m-n+1),
    /// Boyer-Moore uses information gained by preprocessing P to skip as many alignments as possible
    /// </summary>
    public class BooyerMooreAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;
        private const int MAX = 256;

        /// <summary>
        /// Creates new instance of <see cref="BooyerMooreAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public BooyerMooreAlgorithm(string text, string pattern)
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
            int n = _text.Length;
            int[] badChar = new int[MAX];
            int s = 0;
            while(s <= (n-m))
            {
                int j = m - 1;
                while(j >=0 && _pattern[j] == _text[s + j])
                {
                    --j;
                }

                if(j < 0)
                {
                    indexes.Add(s);
                    s += (s + m < n) ? m - badChar[_text[s + m]] : 1;
                }
                else
                {
                    s += Math.Max(1, j - badChar[_text[s + j]]);
                }
            }

            return indexes;
        }

        private void BadCharHeuristic(string str, int size, ref int[] badChar)
        {
            for(int i=0; i< MAX; i++)
            {
                badChar[i] = -1;
            }

            for(int i=0; i< size; i++)
            {
                badChar[(int)str[i]] = i;
            }
        }
    }
}
