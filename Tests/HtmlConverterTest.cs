using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter;
using MarkdownConverter.Converter;
using NUnit.Framework;

namespace Tests
{
    public class HtmlConverterTest
    {
        private HtmlConverter _htmlCoverter;

        [SetUp]
        public void Setup()
        {
            _htmlCoverter = new HtmlConverter();
        }

        [TestCase("testing-input-1.md", "converted-input-1.html")]
        public void ValidateMarkDown2Html(string markdownFile, string htmlFile)
        {
            string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}";
            var seperator = System.IO.Path.DirectorySeparatorChar;
            path = $"{path}{seperator}";
            var markDown = System.IO.File.ReadAllLines($"{path}{seperator}InputsForTesting{seperator}{markdownFile}");
            var html = System.IO.File.ReadAllLines($"{path}{seperator}InputsForTesting{seperator}{htmlFile}").Where(x => !string.IsNullOrWhiteSpace(x));

            List<string> convertedHtml = _htmlCoverter.Convert2Html(markDown);

            Assert.That(convertedHtml, Is.EquivalentTo(html));
        }

        [TestCase("this is a paragraph", TagType.Paragraph)]
        [TestCase("##this is a header", TagType.Header)]
        [TestCase("[Link text](https://www.link.com)", TagType.Link)]
        [TestCase("", TagType.EmptyRow)]
        public void TestIdentifyTagType(string markdown, TagType tagtype)
        {
            Tag returnedTag = _htmlCoverter.IdentifyTagType(markdown);
            Assert.That(returnedTag.TagType, Is.EqualTo(tagtype));
        }
    }


}
