using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter.TagUtilities;
using NUnit.Framework;

namespace Tests
{
    class BoldItalicUtilityTest
    {
        private BoldItalic _boldItalicUtility;

        [SetUp]
        public void Setup()
        {
            _boldItalicUtility = new BoldItalic();
        }

        [TestCase("***this is some bold and italic text***", @"<strong><em>this is some bold and italic text</em></strong>")]
        [TestCase("***this is some bold and italic text*** in a paragraph", @"<strong><em>this is some bold and italic text</em></strong> in a paragraph")]
        public void TestFormatInline(string markdown, string html)
        {
            string formatted = _boldItalicUtility.FormatInline(markdown);
            Assert.That(formatted, Is.EqualTo(html));
        }
    }
}
