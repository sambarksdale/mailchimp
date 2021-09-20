using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter.TagUtilities;
using NUnit.Framework;

namespace Tests
{
    public class BoldUtilityTest
    {
        private Bold _boldUtility;

        [SetUp]
        public void Setup()
        {
            _boldUtility = new Bold();
        }

        [TestCase("**this is some bold text**", @"<strong>this is some bold text</strong>")]
        [TestCase("**this is some bold text** in a paragraph", @"<strong>this is some bold text</strong> in a paragraph")]
        public void TestFormatInline(string markdown, string html)
        {
            string formatted = _boldUtility.FormatInline(markdown);
            Assert.That(formatted, Is.EqualTo(html));
        }
    }
}
