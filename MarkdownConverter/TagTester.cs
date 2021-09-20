using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarkdownConverter
{
	public class TagTester
	{
		#region Header
		public bool IsHeader(Tag tag)
		{
			return tag.InnerHtml[0] == '#' && tag.InnerHtml.IndexOf(' ') < 7;
		}
		#endregion

		#region Link
		public bool IsLink(Tag tag)
		{
			string pattern = @"^\[(.*?)\]\(((?:\/|https?:\/\/)[\w\d.\/?=#]+)\)$";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match m = regex.Match(tag.InnerHtml);

			return m.Success;
		}

		public bool ContainsLink(Tag tag)
		{
			//string pattern = @"\[([\w\s\d]+)\]\(((?:\/|https?:\/\/)[\w\d.\/?=#]+)\)";
			string pattern = @"\[(.*?)\]\(((?:\/|https?:\/\/)[\w\d.\/?=#]+)\)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match m = regex.Match(tag.InnerHtml);

			return m.Success;
		}
		#endregion

		#region Bold
		public bool ContainsBold(Tag tag)
		{
			string pattern = @"(?<=\*\*)(.*?)(?=\*\*)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match m = regex.Match(tag.InnerHtml);

			return m.Success && !ContainsBoldItalic(tag);
		}
		#endregion

		#region Italic
		public bool ContainsItalic(Tag tag)
		{
			string pattern = @"(?<=\*)(.*?)(?=\*)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match m = regex.Match(tag.InnerHtml);

			return m.Success && !ContainsBoldItalic(tag);
		}
		#endregion

		#region Bold & Itallic
		public bool ContainsBoldItalic(Tag tag)
		{
			string pattern = @"(?<=\*\*\*)(.*?)(?=\*\*\*)";
			Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
			Match m = regex.Match(tag.InnerHtml);

			return m.Success;
		}
		#endregion
	}
}
