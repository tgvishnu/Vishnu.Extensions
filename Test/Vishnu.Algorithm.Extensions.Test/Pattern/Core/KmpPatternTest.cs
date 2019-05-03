using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class KmpPatternTest
    {
        [Test]
        public void SuccessTest()
        {
            string text = "ABABAABACDABABCABAB";
            string pattern = "ABA";
            IList<int> exptecedResult = new List<int>() { 0, 2, 5, 10, 15 };
            var result = Algorithm.PatternSearch.UseKmp(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "THIS IS A TEST TEXT";
            pattern = "TEST";
            exptecedResult = new List<int>() { 10 };
            result = Algorithm.PatternSearch.UseKmp(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "the quick brown fox jumps over the lazy dog";
            pattern = "the";
            exptecedResult = new List<int>() { 0, 31 };
            result = Algorithm.PatternSearch.UseKmp(text, pattern);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
