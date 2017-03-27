using System;
namespace yysgl.forms
{
	public interface IPicture
	{
		//http://www.goxuni.com/668633-how-to-save-an-image-to-a-device-using-xuni-and-xamarin-forms/

		void SavePictureToDisk(string filename, byte[] imageData);
	}
}
