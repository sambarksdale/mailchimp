using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MarkdownConverter.Converters;
using MarkdownConverter.TagUtilities;

namespace MarkdownConverter.Converter
{
	public class HtmlConverter
	{
		#region Convert 2 Html
		public List<string> Convert2Html(IEnumerable<string> md)
		{
			List<Tag> tags = new List<Tag>();
			List<string> html = new List<string>();
			

			foreach (string line in md)
			{
				Tag tag = IdentifyTagType(line);
				FormatInlineStyles(tag);

				if (tags.Count > 0)
				{

					Tag lastTag = tags.LastOrDefault();

					if (tag.TagType == lastTag.TagType && CanCombine(tag.TagType))
					{
						lastTag.InnerHtml += $"</br> {tag.InnerHtml}";
					}
					else
					{
						tags.Add(tag);
					}

				}
				else
				{
					tags.Add(tag);
				}
				
			}


			foreach (Tag tag in tags)
			{
				if (tag.TagType.ToString() != "EmptyRow")
				{
					Type type = Type.GetType($"MarkdownConverter.TagUtilities.{tag.TagType.ToString()}");
					IRender converter = (IRender)Activator.CreateInstance(type);
					html.Add(converter.Render(tag.InnerHtml));
				}
			}

			return html;
		}
		#endregion

		#region Identify Tag
		public Tag IdentifyTagType(string line)
		{
			TagTester tester = new TagTester();
			Tag tag = new Tag
			{
				InnerHtml = line.Trim()
			};

			if (String.IsNullOrEmpty(line))
			{
				tag.TagType = TagType.EmptyRow;
			}
			else if (line[0] == '#' && line.IndexOf(' ') < 7)
			{
				tag.TagType = TagType.Header;
			}
			else if (tester.IsLink(tag))
			{
				tag.TagType = TagType.Link;
			}
			else
			{
				tag.TagType = TagType.Paragraph;
			}

			return tag;
		}
		#endregion

		#region Format Inline Styling
		void FormatInlineStyles(Tag tag)
		{
			TagTester tester = new TagTester();
			string foundStyle = null;

			tester.ContainsBold(tag);

			if (tag.TagType != TagType.Link && tester.ContainsLink(tag))
			{
				foundStyle = TagType.Link.ToString();
			}

			if (tester.ContainsBold(tag))
			{
				foundStyle = TagType.Bold.ToString();
			}

			if (tester.ContainsItalic(tag))
			{
				foundStyle = TagType.Italic.ToString();
			}

			if (tester.ContainsBoldItalic(tag))
			{
				foundStyle = TagType.BoldItalic.ToString();
			}

			if (foundStyle != null)
			{
				Type type = Type.GetType($"MarkdownConverter.TagUtilities.{foundStyle}");
				IFormatInline converter = (IFormatInline)Activator.CreateInstance(type);
				tag.InnerHtml = converter.FormatInline(tag.InnerHtml);
				FormatInlineStyles(tag);
			}
		}
		#endregion

		#region Can Combine
		bool CanCombine(TagType tagtype)
		{
			if (tagtype.ToString().Equals("Paragraph"))
			{
				return true;
			}

			return false;
		}
		#endregion
	}
}
