using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using Vishnu.Extensions;
using Vishnu.Extensions.Pattern;

namespace Vishnu.Extensions.Test.Sorting.Core
{
    [TestFixture]
    public class EfficientFinateAutomataPatternTest
    {
        [Test]
        public void SuccessTest()
        {
            string text = "AAAABAACAADAABAAABAA";
            string pattern = "AAA";
            IList<int> exptecedResult = new List<int>() {  0, 14 };
            var result = Algorithm.PatternSearch.UseEfficientFinateAutomata(text, pattern);
            Assert.AreEqual(exptecedResult, result);
            text = "THIS IS A TEST TEXT";
            pattern = "TEST";
            exptecedResult = new List<int>() { 10 };
            result = Algorithm.PatternSearch.UseEfficientFinateAutomata(text, pattern);
            Assert.AreEqual(exptecedResult, result);
        }
    }
}
