using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class ZAlgorithm
    {
        [Test]
        public void SuccessTest()
        {
            string text = "GEEKS FOR GEEKS";
            string pattern = "GEEK";
            IList<int> exptecedResult = new List<int>() { 0, 10 };
            var result = Algorithm.PatternSearch.UseZ(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "THIS IS A TEST TSET";
            pattern = "TEST";
            exptecedResult = new List<int>() { 10 };
            result = Algorithm.PatternSearch.UseZ(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "ABACGABCAMACB";
            pattern = "AB";
            exptecedResult = new List<int>() { 0, 5};
            result = Algorithm.PatternSearch.UseZ(text, pattern);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
