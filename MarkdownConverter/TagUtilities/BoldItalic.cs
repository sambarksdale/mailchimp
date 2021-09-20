using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarkdownConverter.TagUtilities
{
	public class BoldItalic : IFormatInline
	{
		public string FormatInline(string innerHtml)
		{
			string pattern = @"(?<=\*\*\*)(.*?)(?=\*\*\*)";
			string toBoldItalic = Regex.Match(innerHtml, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).ToString();

			return innerHtml.Replace($"***{toBoldItalic}***", $"<strong><em>{toBoldItalic}</em></strong>");
		}
	}
}
