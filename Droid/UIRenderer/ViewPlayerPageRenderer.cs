
using Android.App;
using Android.Gms.Ads;
using Android.Net;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(yysgl.forms.ViewPlayerPage), typeof(yysgl.forms.Droid.VideoPlayerPageRenderer))]
namespace yysgl.forms.Droid
{
	public class VideoPlayerPageRenderer : PageRenderer
	{

		VideoView videoView;
		Android.Views.View view;

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
			{
				return;
			}

			var activity = Context as Activity;
			view = activity.LayoutInflater.Inflate(Resource.Layout.VideoPlayerLayout, this, false);

			try
			{

				SetupUserInterface();
				SetAdView();
				AddView(view);
				//SetupEventHandlers();
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
			}
		}

		private void SetupUserInterface()
		{
			//activity.SetContentView(Resource.Layout.VideoPlayerLayout);
			videoView = view.FindViewById<VideoView>(Resource.Id.videoView);
			//设置视频控制器
			videoView.SetMediaController(new MediaController(Context));

			//设置视频路径
			videoView.SetVideoURI(Uri.Parse((Element as ViewPlayerPage).Url));

			//开始播放视频
			videoView.Start();

		}

		private void SetAdView()
		{
			var adContainer = view.FindViewById<Android.Widget.RelativeLayout>(Resource.Id.adContainer);
			var adView = new NativeExpressAdView(Context);

			adView.AdSize = new AdSize(AdSize.FullWidth, 150);
			adView.AdUnitId = "ca-app-pub-XXXXXXXXXXXXXXX";

			adContainer.AddView(adView);

			adView.LoadAd(new AdRequest
							.Builder()
							.Build());
		}

		protected override void OnDetachedFromWindow()
		{
			base.OnDetachedFromWindow();
			videoView.Pause();
		}

		//http://stackoverflow.com/questions/39630853/xamarin-forms-android-custom-contentpage-pagerenderer-not-rendering-views
		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);

			if (view != null)
			{
				var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
				var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

				view.Measure(msw, msh);
				view.Layout(0, 0, r - l, b - t);
			}
		}

	}
}
