
using CarouselView.FormsPlugin.iOS;
using DLToolkit.Forms.Controls;
using FFImageLoading.Forms.Touch;
using Foundation;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;

namespace yysgl.forms.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			CarouselViewRenderer.Init();
			FlowListView.Init();
			CachedImageRenderer.Init();

			//赋值数据库文件
			FileAccessHelper.GetLocalFilePath("Data.sqlite");

			LoadApplication(new App());

			//var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
			//x = typeof(Xamarin.Forms.Themes.LightThemeResources);
			//x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);

			//initialize MobileAds
			MobileAds.Configure("ca-app-pub-2079580879894926~9738974291");

			return base.FinishedLaunching(app, options);
		}

		public override void PerformActionForShortcutItem(UIApplication application, UIApplicationShortcutItem shortcutItem, UIOperationHandler completionHandler)
		{
			completionHandler(HandleShortcutItem(shortcutItem));
		}

		public bool HandleShortcutItem(UIApplicationShortcutItem shortcutItem)
		{
			//http://www.open-open.com/lib/view/open1452856776230.html
			//https://blog.verslu.is/xamarin/3d-touch-your-xamarin-forms-app-apply-pressure-to-icon-area/
			var handled = false;

			// Anything to process?
			if (shortcutItem == null)
				return false;

			// Take action based on the shortcut type
			switch (shortcutItem.Type)
			{
				case "com.mayuecif.yys-forms.query":
					MessagingCenter.Send(Xamarin.Forms.Application.Current as App, "OpenQueryPage");
					handled = true;
					break;
			}

			// Return results
			return handled;
		}

	}
}
