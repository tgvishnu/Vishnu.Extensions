using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.Extensions.Pattern.Core;

namespace Vishnu.Extensions.Pattern
{
    /// <summary>
    /// Extension methods for pattern search
    /// </summary>
    public static class PatternExtension
    {
        /// <summary>
        /// Use Naive Pattern for searching pattern
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseNaive(this IPattern patternSearch, string text, string pattern)
        {
            return new NaiveAlgorithm(text, pattern).Search();
        }

        /// <summary>
        /// Use KMP Pattern for searching pattern
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseKmp(this IPattern patternSearch, string text, string pattern)
        {
            return new KmpAlgorithm(text, pattern).Search();
        }

        /// <summary>
        /// Use Rabin Krap Pattern for searching pattern
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <param name="primeNumber">Prime number</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseRabinKrap(this IPattern patternSearch, string text, string pattern, int primeNumber)
        {
            return new RabinKrapAlgorithm(text, pattern, primeNumber).Search();
        }

        /// <summary>
        /// Use FianteAutomata Pattern for searching pattern
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseFinateAutomata(this IPattern patternSearch, string text, string pattern)
        {
            return new FiniteAutomataAlgorithm(text, pattern).Search();
        }

        /// <summary>
        /// Use Efficient FianteAutomata Pattern for searching pattern
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseEfficientFinateAutomata(this IPattern patternSearch, string text, string pattern)
        {
            return new EfficientFinateAutomataAlgorithm(text, pattern).Search();
        }

        /// <summary>
        /// Use anagram Pattern for searching pattern.
        /// This algorithm searches for all the occurrences of pattern and its permutations (or anagrams) in the specified text.
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseAnagram(this IPattern patternSearch, string text, string pattern)
        {
            return new AnagramAlgorithm(text, pattern).Search();
        }

        /// <summary>
        /// Use Bitap Pattern for searching pattern.
        /// The algorithm tells whether a given text contains a substring which is "approximately equal" to a given pattern, 
        /// where approximate equality is defined in terms of Levenshtein distance — if the substring and pattern are 
        /// within a given distance k of each other, then the algorithm considers them equal. 
        /// </summary>
        /// <param name="patternSearch"><see cref="IPattern"/></param>
        /// <param name="text">input text</param>
        /// <param name="pattern">pattern text</param>
        /// <returns>List of positions of pattern</returns>
        public static IList<int> UseBitap(this IPattern patternSearch, string text, string pattern)
        {
            return new BitapAlgorithm(text, pattern).Search();
        }

        ///// <summary>
        ///// Use Bitap Pattern for searching pattern using Bad Character
        ///// </summary>
        ///// <param name="patternSearch"><see cref="IPattern"/></param>
        ///// <param name="text">input text</param>
        ///// <param name="pattern">pattern text</param>
        ///// <returns>List of positions of pattern</returns>
        //public static IList<int> UseBooyerMoore(this IPattern patternSearch, string text, string pattern)
        //{
        //    return new BooyerMooreAlgorithm(text, pattern).Search();
        //}
    }
}
