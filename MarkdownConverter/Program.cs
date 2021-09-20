using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MarkdownConverter.Converter;

namespace MarkdownConverter.MarkdownConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}";
			var sperator = System.IO.Path.DirectorySeparatorChar;
			path = $"{path}{sperator}TestInputs";
			string[] files = System.IO.Directory.GetFiles(path, "*.md");

			foreach (string file in files)
			{
				var fileName = System.IO.Path.GetFileName(file);
				var markDown = System.IO.File.ReadAllLines(file);
				
				Console.WriteLine($"Converting {fileName} to html\n");

				Console.WriteLine("` ` `");
				foreach (string line in markDown)
				{
					Console.WriteLine(line);
				}
				Console.WriteLine("` ` `");

				HtmlConverter converter = new HtmlConverter();
				List<string> html = converter.Convert2Html(markDown);

				foreach (string tag in html)
				{
					Console.WriteLine(tag);
				}

				Console.WriteLine("\n\n");
			}

			Console.ReadLine();

		}
	}
}
