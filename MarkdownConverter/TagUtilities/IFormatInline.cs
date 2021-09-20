using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownConverter.TagUtilities
{
	public interface IFormatInline
	{
		string FormatInline(string innerHtml);
	}
}
