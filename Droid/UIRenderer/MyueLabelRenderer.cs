using System;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(yysgl.forms.MyueLabel), typeof(yysgl.forms.Droid.MyueLabelRenderer))]
namespace yysgl.forms.Droid
{
	public class MyueLabelRenderer : ViewRenderer<MyueLabel, TextView>
	{
		//<enum name="marquee_forever" value="-1" />
		int MARQUEE_FOREVER = -1;

		protected override void OnElementChanged(ElementChangedEventArgs<MyueLabel> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				SetNativeControl(new TextView(Context));
			}

			if (e.NewElement != null)
			{

				InitView(e.NewElement);

			}


		}

		void InitView(MyueLabel label)
		{
			Control.Text = label.Text;

			if (label.IsMarquee)
			{

				Control.SetSingleLine(true);
				Control.SetHorizontallyScrolling(true);
				Control.Focusable = true;
				Control.FocusableInTouchMode = true;
				Control.Selected = true;
				Control.Ellipsize = TextUtils.TruncateAt.Marquee;
				Control.SetMarqueeRepeatLimit(MARQUEE_FOREVER);
			}
			else {
				Control.Ellipsize = TextUtils.TruncateAt.Start;
				Control.SetMaxLines(-1);
				Control.Focusable = false;
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == MyueLabel.IsMarqueeProperty.PropertyName)
			{

			}
			else if (e.PropertyName == MyueLabel.TextProperty.PropertyName)
			{
				Control.Text = Element.Text;
			}
		}
	}
}
