using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownConverter
{
	public class Tag
	{
		public string InnerHtml { get; set; }

		public TagType TagType { get; set; }
	}
}
