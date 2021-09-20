using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter;
using NUnit.Framework;

namespace Tests
{
    class TagTesterTest
    {
        private TagTester _tagTester;

        [SetUp]
        public void Setup()
        {
            _tagTester = new TagTester();
        }

        [TestCase("# this is a header", true)]
        [TestCase("####### this is not a header", false)]
        public void IsHeaderTest(string markdown, bool tf)
        {
            Tag tag = new Tag
            {
                InnerHtml = markdown
            };
            Assert.That(_tagTester.IsHeader(tag), Is.EqualTo(tf));
        }

        [TestCase("[Link text](https://www.example.com)", true)]
        [TestCase("[Link text)(https://www.example.com)", false)]
        public void IsLinkTest(string markdown, bool tf)
        {
            Tag tag = new Tag
            { 
                InnerHtml = markdown
            };
            Assert.That(_tagTester.IsLink(tag), Is.EqualTo(tf));
        }

        [TestCase("text with a link [Link text](https://www.example.com)", true)]
        [TestCase("text without a link [Link text)(https://www.example.com)", false)]
        public void ContainsLinkTest(string markdown, bool tf)
        {
            Tag tag = new Tag
            {
                InnerHtml = markdown
            };
            Assert.That(_tagTester.ContainsLink(tag), Is.EqualTo(tf));
        }

        [TestCase("**this text is bold**", true)]
        [TestCase("this text is not bold", false)]
        public void ContainsBoldTest(string markdown, bool tf)
        {
            Tag tag = new Tag
            {
                InnerHtml = markdown
            };
            Assert.That(_tagTester.ContainsBold(tag), Is.EqualTo(tf));
        }

        [TestCase("*this text is italic*", true)]
        [TestCase("this text is not italic", false)]
        public void ContainsItalicTest(string markdown, bool tf)
        {
            Tag tag = new Tag
            {
                InnerHtml = markdown
            };
            Assert.That(_tagTester.ContainsItalic(tag), Is.EqualTo(tf));
        }

        [TestCase("***this text is bold and italic***", true)]
        [TestCase("this text is not bold or italic", false)]
        public void ContainsBoldItalicTest(string markdown, bool tf)
        {
            Tag tag = new Tag
            {
                InnerHtml = markdown
            };
            Assert.That(_tagTester.ContainsBoldItalic(tag), Is.EqualTo(tf));
        }
    }
}
