using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Foundation;

namespace yysgl.forms.iOS
{
	public class FileAccessHelper
	{
		public static string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}

			string dbPath = Path.Combine(libFolder, filename);

			CopyDatabaseIfNotExists(dbPath);

			return dbPath;
		}

		private static void CopyDatabaseIfNotExists(string dbPath)
		{
			var existingDb = NSBundle.MainBundle.PathForResource("Data", "sqlite");
			//判断数据库是否存在 
			if (!File.Exists(dbPath))
			{
				File.Copy(existingDb, dbPath);
			}
			else
			{
				//判断数据库文件MD5值
				if (!FileEquals(dbPath, existingDb))
				{
					File.Delete(dbPath);
					File.Copy(existingDb, dbPath);
				}
			}

		}

		private static bool FileEquals(string path, string path2)
		{
			string path1Md5, path2Md5;
			using (var md5 = MD5.Create())
			{
				using (var stream1 = File.OpenRead(path))
				using (var stream2 = File.OpenRead(path2))
				{
					path1Md5 = Encoding.Default.GetString(md5.ComputeHash(stream1));

					path2Md5 = Encoding.Default.GetString(md5.ComputeHash(stream2));
					//md5.ComputeHash(stream1).SequenceEqual(md5.ComputeHash(stream2));
					//md5.ComputeHash(stream1).Equals(md5.ComputeHash(stream2));
				}

			}
			return path1Md5.Equals(path2Md5);
		}
	}
}
