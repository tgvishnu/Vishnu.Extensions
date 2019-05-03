using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// The FA (Finite Automata) construction method discussed in previous post takes O((m^3)*NO_OF_CHARS) time. 
    /// FA can be constructed in O(m*NO_OF_CHARS) time. In this post, we will discuss the O(m*NO_OF_CHARS) 
    /// algorithm for FA construction. The idea is similar to lps (longest prefix suffix) array construction discussed 
    /// in the KMP algorithm.
    /// </summary>
    public class EfficientFinateAutomataAlgorithm : FiniteAutomataAlgorithm
    {
        /// <summary>
        /// Creates new instance of <see cref="EfficientFinateAutomataAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public EfficientFinateAutomataAlgorithm(string text, string pattern)
            : base(text, pattern)
        {
        }

        /// <summary>
        /// This function builds the TF table which  represents Finite Automata for a given pattern
        /// </summary>
        /// <param name="pattern">search pattern</param>
        /// <param name="m">lenght of pattern</param>
        /// <param name="finateAutomata">computed finate automata</param>
        protected override void ComputeFinateAutomata(char[] pattern, int m, int[,] finateAutomata)
        {
            int i, lps = 0, x;
            for (x = 0; x < _numberOfChars; x++)
            {
                finateAutomata[0, x] = 0;
            }

            finateAutomata[0, _pattern[0]] = 1;
            for(i = 0; i<m; i++)
            {
                // Copy values from row at index lps 
                for(x = 0; x < _numberOfChars; x++)
                {
                    finateAutomata[i, x] = finateAutomata[lps, x];
                }

                // Update the entry corresponding to this character
                finateAutomata[i, pattern[i]] = i + 1;
                // Update lps for next row to be filled 
                if(i<m)
                {
                    lps = finateAutomata[lps, pattern[i]];
                }
            }
        }
    }
}
