using System;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(yysgl.forms.NativeAdView), typeof(yysgl.forms.iOS.NativeAdViewRenderer))]
namespace yysgl.forms.iOS
{
	public class NativeAdViewRenderer : ViewRenderer<NativeAdView, NativeExpressAdView>
	{
		NativeExpressAdView adView;

		protected override void OnElementChanged(ElementChangedEventArgs<NativeAdView> e)
		{
			base.OnElementChanged(e);
			if (Control == null)
			{
				CreateNativeControl();
				SetNativeControl(adView);
				AddSubview(adView);
			}
		}


		NativeExpressAdView CreateNativeControl()
		{
			if (adView != null)
				return adView;

			adView = new NativeExpressAdView(AdSizeCons.GetFullWidthPortrait(150));

			adView.AdUnitID = "ca-app-pub-2079580879894926/7431309498";
			adView.RootViewController = GetVisibleViewController();

			// Wire AdReceived event to know when the Ad is ready to be displayed
			adView.AdReceived += (object sender, EventArgs e) =>
			{

			};
			var request = Request.GetDefaultRequest();
			//request.TestDevices = new[] { Request.SimulatorId.ToString() };
			adView.LoadRequest(request);
			return adView;
		}

		/// 
		/// Gets the visible view controller.
		/// 
		/// The visible view controller.
		UIViewController GetVisibleViewController()
		{
			var window = UIApplication.SharedApplication.KeyWindow;
			if (window == null)
				throw new InvalidOperationException("There's no current active window");

			var rootController = window.RootViewController;

			if (rootController.PresentedViewController == null)
				return rootController;

			if (rootController.PresentedViewController is UINavigationController)
			{
				return ((UINavigationController)rootController.PresentedViewController).VisibleViewController;
			}

			if (rootController.PresentedViewController is UITabBarController)
			{
				return ((UITabBarController)rootController.PresentedViewController).SelectedViewController;
			}

			return rootController.PresentedViewController;
		}
	}
}
