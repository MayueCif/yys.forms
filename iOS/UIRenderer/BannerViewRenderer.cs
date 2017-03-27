
using System;
using CoreGraphics;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using AdsBannerView = Google.MobileAds.BannerView;

[assembly: ExportRenderer(typeof(yysgl.forms.BannerView), typeof(yysgl.forms.iOS.BannerViewRenderer))]
namespace yysgl.forms.iOS
{
	public class BannerViewRenderer : ViewRenderer<BannerView, AdsBannerView>
	{
		AdsBannerView adView;

		protected override void OnElementChanged(ElementChangedEventArgs<BannerView> e)
		{
			base.OnElementChanged(e);
			if (Control == null)
			{
				CreateNativeControl();
				SetNativeControl(adView);
				AddSubview(adView);
			}
		}


		AdsBannerView CreateNativeControl()
		{
			if (adView != null)
				return adView;



			// Setup your BannerView, review AdSizeCons class for more Ad sizes. 
			adView = new AdsBannerView(size: AdSizeCons.SmartBannerPortrait,
										   origin: new CGPoint(0, UIScreen.MainScreen.Bounds.Size.Height - AdSizeCons.Banner.Size.Height))
			{
				AdUnitID = "ca-app-pub-2079580879894926/2215707492",
				RootViewController = GetVisibleViewController()
			};

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
