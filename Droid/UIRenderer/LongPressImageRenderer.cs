

using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(yysgl.forms.LongPressImage), typeof(yysgl.forms.Droid.LongPressImageRenderer))]
namespace yysgl.forms.Droid
{
	public class LongPressImageRenderer : ImageRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			Control.LongClick += (sender, e1) =>
			{
				(Element as LongPressImage).OnLongPress();
			};

		}
	}

}
