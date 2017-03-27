using System;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WebView), typeof(yysgl.forms.Droid.CustomWebViewRenderer))]
namespace yysgl.forms.Droid
{
	public class CustomWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			base.OnElementChanged(e);
			Control.VerticalScrollBarEnabled = false;
			Control.HorizontalScrollBarEnabled = false;
			Control.Settings.JavaScriptEnabled = true;

			//解决Https 图片不显示问题
			if (Build.VERSION.SdkInt > Android.OS.BuildVersionCodes.Lollipop)
			{
				Control.Settings.MixedContentMode = Android.Webkit.MixedContentHandling.AlwaysAllow;
			}

		}
	}
}
