
using Android.Content;
using Android.Net;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(yysgl.forms.Droid.Picture))]
namespace yysgl.forms.Droid
{
	public class Picture : IPicture
	{
		public void SavePictureToDisk(string filename, byte[] imageData)
		{
			var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
			var pictures = dir.AbsolutePath;
			//adding a time stamp time file name to allow saving more than one image... otherwise it overwrites the previous saved image of the same name
			var name = filename + ".jpg";
			var filePath = System.IO.Path.Combine(pictures, name);
			try
			{
				System.IO.File.WriteAllBytes(filePath, imageData);
				//mediascan adds the saved image into the gallery
				var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
				mediaScanIntent.SetData(Uri.FromFile(new File(filePath)));
				Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
			}
			catch (System.Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}
	}
}
