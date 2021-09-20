using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarkdownConverter.TagUtilities
{
	public class Bold : IFormatInline
	{
		public string FormatInline(string innerHtml)
		{
			string pattern = @"(?<=\*\*)(.*?)(?=\*\*)";
			string toBold = Regex.Match(innerHtml, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).ToString();

			return innerHtml.Replace($"**{toBold}**", $"<strong>{toBold}</strong>");
		}
	}
}
