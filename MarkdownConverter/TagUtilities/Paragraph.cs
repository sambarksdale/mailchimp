using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter.Converters;

namespace MarkdownConverter.TagUtilities
{
	public class Paragraph : IRender
	{
		public string Render(string innerHtml)
		{
			return $"<p>{innerHtml}</p>";
		}
	}
}
