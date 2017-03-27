using System;
using Android.Gms.Ads;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(yysgl.forms.NativeAdView), typeof(yysgl.forms.Droid.NativeAdViewRenderer))]
namespace yysgl.forms.Droid
{
	public class NativeAdViewRenderer : ViewRenderer<NativeAdView, NativeExpressAdView>
	{
		string adUnitId = "ca-app-pub-2079580879894926/7431309498";
		NativeExpressAdView adView;

		protected override NativeExpressAdView CreateNativeControl()
		{
			if (adView != null)
				return adView;

			adView = new NativeExpressAdView(Forms.Context);
			adView.AdSize = new AdSize(AdSize.FullWidth, 150);
			adView.AdUnitId = adUnitId;

			adView.LoadAd(new AdRequest
							.Builder()
							.Build());

			return adView;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<NativeAdView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				CreateNativeControl();
				SetNativeControl(adView);
			}
		}

	}
}
