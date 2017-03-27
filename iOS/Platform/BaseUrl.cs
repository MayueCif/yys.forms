using System;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(yysgl.forms.iOS.BaseUrl))]
namespace yysgl.forms.iOS
{
	public class BaseUrl : IBaseUrl
	{
		public string Get()
		{
			return NSBundle.MainBundle.BundlePath;
		}
	}
}
