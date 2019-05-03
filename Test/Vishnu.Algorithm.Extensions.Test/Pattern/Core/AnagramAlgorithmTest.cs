using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class AnagramAlgorithmTest
    {
        [Test]
        public void SuccessTest()
        {
            string text = "NBACGABCAMACB";
            string pattern = "ABC";
            IList<int> exptecedResult = new List<int>() { 1, 5, 6, 10 };
            var result = Algorithm.PatternSearch.UseAnagram(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "THIS IS A TEST TSET";
            pattern = "TEST";
            exptecedResult = new List<int>() { 10, 15 };
            result = Algorithm.PatternSearch.UseAnagram(text, pattern);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
