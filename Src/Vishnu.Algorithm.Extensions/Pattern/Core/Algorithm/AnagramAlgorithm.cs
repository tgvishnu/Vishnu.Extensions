using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// This algorithm searches for all the occurrences of pattern and its permutations (or anagrams) in the specified text.
    /// </summary>
    public class AnagramAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;
        private const int MAX = 256;

        /// <summary>
        /// Creates new instance of <see cref="AnagramAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public AnagramAlgorithm(string text, string pattern)
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
            char[] countP = new char[MAX];
            char[] countT = new char[MAX];
            for(int i=0; i< _pattern.Length; i++)
            {
                (countP[_pattern[i]])++;
                (countT[_text[i]])++;
            }

            for(int i= _pattern.Length; i< _text.Length; ++i)
            {
                if(this.Compare(countP, countT))
                {
                    indexes.Add(i - _pattern.Length);
                }

                (countT[_text[i]])++;
                countT[_text[i - _pattern.Length]]--;
            }

            if(this.Compare(countP, countT))
            {
                indexes.Add(_text.Length - _pattern.Length);
            }
           
            return indexes;
        }

        private bool Compare(char[] arr1, char[] arr2)
        {
            for(int i=0; i<MAX; ++i)
            {
                if(arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
