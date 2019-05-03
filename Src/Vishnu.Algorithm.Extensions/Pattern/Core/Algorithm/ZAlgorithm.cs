using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// This algorithm finds all occurrences of a pattern in a text in linear time. 
    /// Let length of text be n and of pattern be m, then total time taken is O(m + n) with linear space complexity. 
    /// </summary>
    public class ZAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;

        /// <summary>
        /// Creates new instance of <see cref="ZAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public ZAlgorithm(string text, string pattern)
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
            string contcat = _pattern + "$" + _text;
            int l = contcat.Length;
            int[] zArray = new int[l];
            this.GetZArray(contcat, zArray);
            for(int i=0; i<l; i++)
            {
                if(zArray[i] == _pattern.Length)
                {
                    indexes.Add(i - _pattern.Length - 1);
                }
            }

            return indexes;
        }

        /// <summary>
        ///  Fills Z array for given string str[]  
        /// </summary>
        /// <param name="inputWithPattern">concatinated input</param>
        /// <param name="zArray">Z array</param>
        private void GetZArray(string inputWithPattern, int[] zArray)
        {

            int n = inputWithPattern.Length;

            // [L,R] make a window which  matches with prefix of s  
            int l = 0, r = 0;

            for (int i = 1; i < n; ++i)
            {

                // if i>R nothing matches so we will  calculate. Z[i] using naive way.  
                if (i > r)
                {
                    l = r = i;

                    // R-L = 0 in starting, so it will start  checking from 0'th index. For example,  
                    // for "ababab" and i = 1, the value of R  remains 0 and Z[i] becomes 0. For string  
                    // "aaaaaa" and i = 1, Z[i] and R become 5  
                    while (r < n && inputWithPattern[r - l] == inputWithPattern[r])
                    {
                        r++;
                    }

                    zArray[i] = r - l;
                    r--;

                }
                else
                {

                    // k = i-L so k corresponds to number  
                    // which matches in [L,R] interval.  
                    int k = i - l;

                    // if Z[k] is less than remaining interval  
                    // then Z[i] will be equal to Z[k].  
                    // For example, str = "ababab", i = 3,  
                    // R = 5 and L = 2  
                    if (zArray[k] < r - i + 1)
                    {
                        zArray[i] = zArray[k];
                    }

                    // For example str = "aaaaaa" and  
                    // i = 2, R is 5, L is 0  
                    else
                    {


                        // else start from R and  
                        // check manually  
                        l = i;
                        while (r < n && inputWithPattern[r - l] == inputWithPattern[r])
                        {
                            r++;
                        }

                        zArray[i] = r - l;
                        r--;
                    }
                }
            }
        }
    }
}
