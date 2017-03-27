
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(yysgl.forms.LongPressImage), typeof(yysgl.forms.iOS.LongPressImageRenderer))]
namespace yysgl.forms.iOS
{
	public class LongPressImageRenderer : ImageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			var longPressImage = Element as LongPressImage;
			var gr = new UILongPressGestureRecognizer(o => longPressImage.OnLongPress());

			AddGestureRecognizer(gr);
		}
	}
}
