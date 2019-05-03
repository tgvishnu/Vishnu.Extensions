using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.Extensions.Pattern.Core
{
    /// <summary>
    /// FA based algorithm, we preprocess the pattern and build a 2D array that represents a Finite Automata. 
    /// Construction of the FA is the main tricky part of this algorithm. 
    /// Once the FA is built, the searching is simple. In search, we simply need to start from the first state of 
    /// the automata and the first character of the text. At every step, we consider next character of text, 
    /// look for the next state in the built FA and move to a new state. If we reach the final state, then
    /// the pattern is found in the text. The time complexity of the search process is O(n).
    /// </summary>
    public class FiniteAutomataAlgorithm : IPatternAlgorithm
    {
        protected readonly string _text;
        protected readonly string _pattern;
        protected readonly int _numberOfChars = 256;
        /// <summary>
        /// Creates new instance of <see cref="FiniteAutomataAlgorithm"/> class
        /// </summary>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern to search</param>
        public FiniteAutomataAlgorithm(string text, string pattern)
        {
            _text = text;
            _pattern = pattern;
        }

        /// <summary>
        /// Searches for specific pattern
        /// </summary>
        /// <returns></returns>
        public virtual IList<int> Search()
        {
            List<int> indexes = new List<int>();
            int n = _text.Length;
            int m = _pattern.Length;
            char[] patternArray = _pattern.ToCharArray();
            char[] textArray = _text.ToCharArray();
            int[,] finateAutomata = new int[m + 1, _numberOfChars];
            this.ComputeFinateAutomata(patternArray, m, finateAutomata);
            int state = 0;
            for(int i=0; i<n; i++)
            {
                state = finateAutomata[state, _text[i]];
                if(state == m)
                {
                    indexes.Add(i - m + 1);
                }
            }

            return indexes;
        }

        /// <summary>
        /// This function builds the TF table which  represents Finite Automata for a given pattern
        /// </summary>
        /// <param name="pattern">search pattern</param>
        /// <param name="m">lenght of pattern</param>
        /// <param name="finateAutomata">computed finate automata</param>
        protected virtual void ComputeFinateAutomata(char[] pattern, int m, int[,] finateAutomata)
        {
            for (int state = 0; state <= m; ++state)
            {
                for (int x = 0; x < _numberOfChars; ++x)
                {
                    finateAutomata[state,x] = this.GetNextState(pattern, m, state, x);
                }
            }
        }

        /// <summary>
        /// Gets next state
        /// </summary>
        /// <param name="pattern">search pattern</param>
        /// <param name="m">pattern length</param>
        /// <param name="state">state</param>
        /// <param name="x">position</param>
        /// <returns>next state</returns>
        private int GetNextState(char[] pattern, int m, int state, int x)
        {
            // If the character c is same as next  character in pattern,then simply  increment state  
            if (state < m && (char)x == pattern[state])
            {
                return state + 1;
            }

            int i;
            // ns finally contains the longest  prefix which is also suffix in  "pat[0..state-1]c"  
            // Start from the largest possible value and stop when you find a  prefix which is also suffix  
            for (int ns = state; ns > 0; ns--)
            {
                if (pattern[ns - 1] == (char)x)
                {
                    for (i = 0; i < ns - 1; i++)
                    {
                        if (pattern[i] != pattern[state - ns + 1 + i])
                        {
                            break;
                        }
                    }

                    if (i == ns - 1)
                    {
                        return ns;
                    }
                }
            }

            return 0;
        }
    }
}
