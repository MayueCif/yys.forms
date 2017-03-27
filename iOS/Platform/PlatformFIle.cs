using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

[assembly: Dependency(typeof(yysgl.forms.iOS.PlatformFIle))]
namespace yysgl.forms.iOS
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
			string filename = Path.Combine(folder, fileName);
			using (FileStream fsWrite = new FileStream(filename, FileMode.Append))
			{
				fsWrite.Write(data, 0, data.Length);
			};
		}
	}
}
