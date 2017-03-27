using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.iOS.Share))]
namespace yysgl.forms.iOS
{
	public class Share : IShare
	{
		public void Open(string title, string url = null, string imageName = null)
		{
			var activityItems = new List<NSObject>();
			activityItems.Add((NSString)title);
			if (!string.IsNullOrEmpty(url))
			{
				activityItems.Add(new NSUrl(url));
			}
			if (!string.IsNullOrEmpty(imageName))
			{
				activityItems.Add(new UIImage(imageName));
			}

			UIActivityViewController controller = new UIActivityViewController(activityItems.ToArray(), null);

			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;
			while (vc.PresentedViewController != null)
			{
				vc = vc.PresentedViewController;
			}
			vc.PresentViewController(controller, true, null);
		}
	}
}
