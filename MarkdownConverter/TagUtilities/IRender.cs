using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownConverter.Converters
{
	public interface IRender
	{
		string Render(string innerHtml);
	}
}
