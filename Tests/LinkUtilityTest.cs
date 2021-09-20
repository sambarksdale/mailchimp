using MarkdownConverter.TagUtilities;
using NUnit.Framework;

namespace Tests
{
    public class LinkUtilityTest
    {
        private Link _linkUtility;

        [SetUp]
        public void Setup()
        {
            _linkUtility = new Link();
        }

        [TestCase("[Link text](https://www.link.com)", @"<a href=""https://www.link.com"">Link text</a>")]
        [TestCase("[Another Test Link](https://www.anotherlink.com)", @"<a href=""https://www.anotherlink.com"">Another Test Link</a>")]
        public void TestRender(string markdown, string html)
        {
            string rendered = _linkUtility.Render(markdown);
            Assert.That(rendered, Is.EqualTo(html));
        }

        [TestCase("This is sample markdown for the [Mailchimp](https://www.link.com) homework assignment", @"This is sample markdown for the <a href=""https://www.link.com"">Mailchimp</a> homework assignment")]
        [TestCase("## This is a header [with a link](http://anotherlink.com)", @"## This is a header <a href=""http://anotherlink.com"">with a link</a>")]
        public void TestFormatInline(string markdown, string html)
        {
            string formatted = _linkUtility.FormatInline(markdown);
            Assert.That(formatted, Is.EqualTo(html));
        }
    }
}
