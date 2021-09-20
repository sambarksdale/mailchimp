using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MarkdownConverter.Converters;
using MarkdownConverter.TagUtilities;

namespace MarkdownConverter.TagUtilities
{
	public class Link : IRender, IFormatInline
	{
		public string Render(string innerHtml)
		{
			string text = TextFromString(innerHtml);
			string href = HrefFromString(innerHtml);

			return $"<a href=\"{href}\">{text}</a>";
		}

		public string FormatInline(string innerHtml)
		{
			int startIndex = innerHtml.IndexOf('[');
			int endIndex = innerHtml.IndexOf(')');

			string ml = innerHtml.Substring(startIndex, (endIndex - startIndex + 1));

			string text = TextFromString(ml);
			string href = HrefFromString(ml);

			return innerHtml.Replace(ml, $"<a href=\"{href}\">{text}</a>");
		}

		private string TextFromString(string ml) 
		{
			string pattern = @"(?<=\[)(.*?)(?=\])";
			return Regex.Match(ml, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).ToString();
		}

		private string HrefFromString(string ml)
		{
			string pattern = @"(?<=\()(.*?)(?=\))"; ;
			return Regex.Match(ml, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).ToString();
		}
	}
}
