using System;
using MarqueeLabelBinding;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(yysgl.forms.MyueLabel), typeof(yysgl.forms.iOS.MyueLabelRenderer))]
namespace yysgl.forms.iOS
{
	public class MyueLabelRenderer : ViewRenderer<MyueLabel, MarqueeLabel>
	{

		protected override void OnElementChanged(ElementChangedEventArgs<MyueLabel> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				//MarqueeLabel *lengthyLabel = [[MarqueeLabel alloc] initWithFrame:aFrame duration:8.0 andFadeLength:10.0f];
				SetNativeControl(new MarqueeLabel());
			}

			if (e.NewElement != null)
			{
				Control.Text = e.NewElement.Text;
				if (e.NewElement.IsMarquee)
				{

					//		UIView.animateWithDuration(12.0, delay: 1, options: ([.CurveLinear, .Repeat]), animations: {
					//			()->Void in
					//         self.firstLabel.center = CGPointMake(0 - self.firstLabel.bounds.size.width / 2, self.firstLabel.center.y)

					//}, completion: { _ in })
					//	}
					//}

					//UIView.Animate(12.0f, 1, UIViewAnimationOptions.CurveLinear, () =>
					// {
					//	 Control.Center = new CoreGraphics.CGPoint(0 - Control.Bounds.Size.Width / 2, Control.Center.Y);

					// }, () =>
					//  {

					//  });

					Control.MarqueeType = MarqueeType.LeftRight;

				}
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


		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (this.Control != null)
			{
				this.Control.Dispose();
			}
		}

	}
}
