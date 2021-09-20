using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter.TagUtilities;
using NUnit.Framework;

namespace Tests
{
    class HeaderUtilityTest
    {
        private Header _headerUtility;

        [SetUp]
        public void Setup()
        {
            _headerUtility = new Header();
        }

        [TestCase("# this is a header", @"<h1>this is a header</h1>")]
        [TestCase("## this is a header", @"<h2>this is a header</h2>")]
        [TestCase("### this is a header", @"<h3>this is a header</h3>")]
        [TestCase("#### this is a header", @"<h4>this is a header</h4>")]
        [TestCase("##### this is a header", @"<h5>this is a header</h5>")]
        [TestCase("###### this is a header", @"<h6>this is a header</h6>")]
        public void TestRender(string markdown, string html)
        {
            string formatted = _headerUtility.Render(markdown);
            Assert.That(formatted, Is.EqualTo(html));
        }
    }
}
