
using System.Drawing;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using yysgl.forms.iOS;

[assembly: ExportRenderer(typeof(yysgl.forms.ExBoxView), typeof(ExBoxViewRenderer))]
namespace yysgl.forms.iOS
{
	public class ExBoxViewRenderer : BoxRenderer
	{
		public override void Draw(CoreGraphics.CGRect rect)
		{
			base.Draw(rect);

			var exBoxView = (ExBoxView)Element;
			using (var context = UIGraphics.GetCurrentContext())
			{
				var shadowSize = exBoxView.ShadowSize;
				var blur = shadowSize;
				var radius = exBoxView.Radius;

				context.SetFillColor(exBoxView.Color.ToCGColor());
				var bounds = Bounds.Inset(shadowSize * 2, shadowSize * 2);
				context.AddPath(CGPath.FromRoundedRect(bounds, radius, radius));
				context.SetShadow(new SizeF(shadowSize, shadowSize), blur);
				context.DrawPath(CGPathDrawingMode.Fill);
			}

		}


		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == "Radius")
			{
				SetNeedsDisplay();
			}
		}
	}
}
