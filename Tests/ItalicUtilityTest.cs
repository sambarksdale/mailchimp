using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter.TagUtilities;
using NUnit.Framework;

namespace Tests
{
    public class ItalicUtilityTest
    {
        private Italic _italicUtility;

        [SetUp]
        public void Setup()
        {
            _italicUtility = new Italic();
        }

        [TestCase("*this is some italic text*", @"<em>this is some italic text</em>")]
        [TestCase("*this is some italic text* in a paragraph", @"<em>this is some italic text</em> in a paragraph")]

        public void TestRender(string markdown, string html)
        {
            string formatted = _italicUtility.FormatInline(markdown);
            Assert.That(formatted, Is.EqualTo(html));
        }
    }
}
