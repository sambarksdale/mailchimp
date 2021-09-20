using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownConverter.Converters;

namespace MarkdownConverter.TagUtilities
{
	public class Header : IRender
	{
		public string Render(string innerHtml)
		{
			int size = innerHtml.IndexOf(' ');
			return $"<h{size}>{innerHtml.Substring(size + 1)}</h{size}>";
		}
	}
}
