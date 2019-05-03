using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class BitapAlgorithm
    {
        [Test]
        public void SuccessTest()
        {
            string text = "The quick brown fox jumps over the lazy dog and fox";
            string pattern = "fox";
            IList<int> exptecedResult = new List<int>() { 16, 48 };
            var result = Algorithm.PatternSearch.UseBitap(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "THIS IS A TEST TSET";
            pattern = "TEST";
            exptecedResult = new List<int>() { 10 };
            result = Algorithm.PatternSearch.UseBitap(text, pattern);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
