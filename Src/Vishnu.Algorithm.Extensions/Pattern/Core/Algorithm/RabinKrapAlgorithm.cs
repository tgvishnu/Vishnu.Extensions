using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// Rabin-Karp algorithm also slides the pattern one by one. But unlike the Naive algorithm,
    /// Rabin Karp algorithm matches the hash value of the pattern with the hash value of current
    /// substring of text, and if the hash values match then only it starts matching individual 
    /// characters
    /// </summary>
    public class RabinKrapAlgorithm : IPatternAlgorithm
    {
        private readonly string _text;
        private readonly string _pattern;
        private readonly int _primeNumber;
        private readonly int D = 256;
        /// <summary>
        /// Creates new instance of <see cref="RabinKrapAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        /// <param name="primeNumber">Any prime number</param>
        public RabinKrapAlgorithm(string text, string pattern, int primeNumber)
        {
            _text = text;
            _pattern = pattern;
            _primeNumber = primeNumber;
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
            int i, j;
            int patternHash = 0; // hash value of pattern
            int textHash = 0; // hash value of text;
            int h = 1;
            // The value of h would be "pow(d, M-1)%q"  
            for (i = 0; i < m -1 ; i++)
            {
                h = (h * D) % _primeNumber;
            }

            // Calculate the hash value of pattern and first  
            // window of text 

            for (i = 0; i < m; i++)
            {
                patternHash = (D * patternHash + _pattern[i]) % _primeNumber;
                textHash = (D * textHash + _text[i]) % _primeNumber;
            }

            // Slide the pattern over text one by one 
            for (i = 0; i < n - m; i++)
            {
                // Check the hash values of current window of text  
                // and pattern. If the hash values match then only  
                // check for characters on by one  
                if (patternHash == textHash)
                {
                    /* Check for characters one by one */
                    for (j = 0; j < m; j++)
                    {
                        if (_text[j + i] != _pattern[j])
                        {
                            break;
                        }
                    }

                    // if p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1]  
                    if (j == m)
                    {
                        indexes.Add(i);
                    }
                }

                // Calculate hash value for next window of text: Remove  
                // leading digit, add trailing digit  
                if (i < n - m)
                {
                    textHash = (D * (textHash - _text[i] * h) + _text[i + m]) % _primeNumber;
                    // We might get negative value of t, converting it  
                    // to positive 
                    if(textHash < 0)
                    {
                        textHash = (textHash + _primeNumber);
                    }
                }
            }

            return indexes;
        }
    }
}
