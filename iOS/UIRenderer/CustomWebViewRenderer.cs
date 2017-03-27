using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(WebView), typeof(yysgl.forms.iOS.CustomWebViewRenderer))]
namespace yysgl.forms.iOS
{
	public class CustomWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			this.ScrollView.ShowsVerticalScrollIndicator = false;
			this.ScrollView.ShowsHorizontalScrollIndicator = false;
		}
	}
}
