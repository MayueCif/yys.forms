using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Android.App;

namespace yysgl.forms.Droid
{
	public class FileAccessHelper
	{
		public static string GetLocalFilePath(string filename)
		{
			var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var dbPath = Path.Combine(path, filename);

			CopyDatabaseIfNotExists(dbPath);

			return dbPath;
		}

		private static void CopyDatabaseIfNotExists(string dbPath)
		{
			var stream = Application.Context.Assets.Open("Data.sqlite");

			if (!File.Exists(dbPath))
			{
				CopyFile(stream, dbPath);
			}
			else
			{
				if (!FileEquals(dbPath, stream))
				{
					CopyFile(stream, dbPath);
				}
			}
		}

		private static void CopyFile(Stream stream, string toPath)
		{
			using (var br = new BinaryReader(stream))
			{
				using (var bw = new BinaryWriter(new FileStream(toPath, FileMode.Create)))
				{
					byte[] buffer = new byte[2048];
					int length = 0;
					while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
					{
						bw.Write(buffer, 0, length);
					}
				}
			}
		}


		private static bool FileEquals(string path, Stream stream)
		{
			string pathMd5, streamMd5;
			using (var md5 = MD5.Create())
			{
				using (var _stream = File.OpenRead(path))
				{
					pathMd5 = Encoding.Default.GetString(md5.ComputeHash(_stream));
				}
				streamMd5 = Encoding.Default.GetString(md5.ComputeHash(stream));
			}
			return pathMd5.Equals(streamMd5);
		}
	}
}
