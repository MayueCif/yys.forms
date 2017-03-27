using System;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.iOS.AppScore))]
namespace yysgl.forms.iOS
{
	public class AppScore : IAppScore
	{
		public void StartAppScore()
		{
			var url = "itms-apps://itunes.apple.com/app/1208535392";
			UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(url));

			//借助StoreKit.framework 应用内置评分
			//https://developer.xamarin.com/guides/ios/platform_features/introduction_to_ios_6/changes_to_storekit/

		}
	}
}
