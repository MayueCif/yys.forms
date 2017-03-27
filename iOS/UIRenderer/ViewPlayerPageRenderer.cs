using System;
using AVFoundation;
using AVKit;
using CoreGraphics;
using Foundation;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(yysgl.forms.ViewPlayerPage), typeof(yysgl.forms.iOS.VideoPlayerPageRenderer))]
namespace yysgl.forms.iOS
{
	public class VideoPlayerPageRenderer : PageRenderer
	{
		AVPlayer player;
		AVPlayerViewController playerView;

		//admob原生广告
		NativeExpressAdView adView;

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
			{
				return;
			}

			try
			{
				SetupUserInterface();
				//SetupEventHandlers();
				//SetupLiveCameraStream();
				//AuthorizeCameraUse();
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
			}

		}

		private void SetupUserInterface()
		{
			var playerUrl = new NSUrl((Element as ViewPlayerPage).Url);
			playerView = new AVPlayerViewController();
			var playerItem = new AVPlayerItem(playerUrl);
			player = new AVPlayer(playerItem);

			//var layer = new AVPlayerLayer();
			////给AVPlayer一个播放的layer层
			//layer.Player = player;
			//layer.Frame = new CoreGraphics.CGRect(0, 100, View.Frame.Size.Width, 600);
			//layer.BackgroundColor = UIColor.Gray.CGColor;
			////设置AVPlayer的填充模式
			//layer.VideoGravity = AVLayerVideoGravity.Resize;
			//View.Layer.AddSublayer(layer);
			//player.Play();

			playerView.View.Frame = new CoreGraphics.CGRect(0, (View.Frame.Size.Height - 320) / 2, View.Frame.Size.Width, 320);
			playerView.ShowsPlaybackControls = true;
			playerView.Player = player;
			playerView.View.TranslatesAutoresizingMaskIntoConstraints = true;
			View.AddSubview(playerView.View);
			ViewController.PresentViewController(playerView, true, null);
			player.Play();
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.Portrait | UIInterfaceOrientationMask.LandscapeLeft;
		}

		public override bool ShouldAutorotate()
		{
			return true;
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			player.Pause();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			SetAdView();
		}

		private void SetAdView()
		{
			adView = new NativeExpressAdView(AdSizeCons.GetFullWidthPortrait(150));

			adView.AdUnitID = "ca-app-pub-2079580879894926/7431309498";
			adView.RootViewController = ViewController;

			// The video options object can be used to control the initial mute state of video assets.
			// By default, they start muted.
			var videoOptions = new VideoOptions();
			videoOptions.StartMuted = true;
			adView.SetAdOptions(new AdLoaderOptions[] { videoOptions });

			View.AddSubview(adView);
			var request = Request.GetDefaultRequest();
			//request.TestDevices = new[] { Request.SimulatorId.ToString() };
			adView.LoadRequest(request);

		}
	}
}
