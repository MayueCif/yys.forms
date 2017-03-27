using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Ads;
using Android.Widget;

[assembly: ExportRenderer(typeof(yysgl.forms.BannerView), typeof(yysgl.forms.Droid.BannerViewRenderer))]
namespace yysgl.forms.Droid
{
	public class BannerViewRenderer : ViewRenderer<BannerView, AdView>
	{
		string adUnitId = "ca-app-pub-2079580879894926/3832041491";
		AdView adView;

		protected override AdView CreateNativeControl()
		{
			if (adView != null)
				return adView;

			//adView = new AdView(Forms.Context);
			//adView.AdSize = AdSize.SmartBanner;
			//adView.AdUnitId = adUnitId;

			//var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

			//adView.LayoutParameters = adParams;

			//adView.LoadAd(new AdRequest
			//				.Builder()
			//				.Build());

			adView = new AdView(Forms.Context);
			adView.AdSize = AdSize.SmartBanner;
			adView.AdUnitId = adUnitId;

			var requestbuilder = new AdRequest.Builder();
			adView.LoadAd(requestbuilder.Build());

			return adView;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<BannerView> e)
		{
			base.OnElementChanged(e);

			base.OnElementChanged(e);
			if (Control == null)
			{
				CreateNativeControl();
				SetNativeControl(adView);
			}

		}

	}
}
