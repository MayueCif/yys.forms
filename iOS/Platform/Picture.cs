using System;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(yysgl.forms.iOS.Picture))]
namespace yysgl.forms.iOS
{
	public class Picture : IPicture
	{
		public void SavePictureToDisk(string filename, byte[] imageData)
		{
			var image = new UIImage(NSData.FromArray(imageData));
			image.SaveToPhotosAlbum((_image, error) =>
			{
				//you can retrieve the saved UI Image as well if needed using
				//var i = image as UIImage;
				if (error != null)
				{
					Console.WriteLine(error.ToString());
				}
			});
		}
	}
}
