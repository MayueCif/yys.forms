using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System.IO;

[assembly: Dependency(typeof(yysgl.forms.Droid.PlatformFIle))]
namespace yysgl.forms.Droid
{
	public class PlatformFIle : IPlatformFIle
	{
		static string folder = "";

		static PlatformFIle()
		{
			folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		}

		public void Delete(string fileName)
		{
			string filename = Path.Combine(folder, fileName);
			File.Delete(filename);
		}

		public bool Exists(string fileName)
		{
			string filename = Path.Combine(folder, fileName);
			return File.Exists(filename);
		}

		public Task<IEnumerable<string>> GetFilesAsync()
		{
			var filenames =
				from filepath in Directory.EnumerateFiles(folder)
				select Path.GetFileName(filepath);

			return Task.FromResult(filenames);
		}

		public void Save(string fileName, byte[] data)
		{

		}
	}
}
