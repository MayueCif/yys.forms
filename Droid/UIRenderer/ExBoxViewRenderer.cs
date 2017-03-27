
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using yysgl.forms.Droid;

[assembly: ExportRenderer(typeof(yysgl.forms.ExBoxView), typeof(ExBoxViewRenderer))]
namespace yysgl.forms.Droid
{
	public class ExBoxViewRenderer : BoxRenderer
	{
		public override void Draw(Canvas canvas)
		{
			base.Draw(canvas);

			var exBoxView = (ExBoxView)Element;

			using (var paint = new Paint())
			{

				var shadowSize = exBoxView.ShadowSize;
				var blur = shadowSize;
				var radius = exBoxView.Radius;

				paint.AntiAlias = true;

				// 影の描画（1）
				paint.Color = (Xamarin.Forms.Color.FromRgba(0, 0, 0, 112)).ToAndroid();
				paint.SetMaskFilter(new BlurMaskFilter(blur, BlurMaskFilter.Blur.Normal));
				var rectangle = new RectF(shadowSize, shadowSize, Width - shadowSize, Height - shadowSize);
				canvas.DrawRoundRect(rectangle, radius, radius, paint);

				// 本体の描画（2）
				paint.Color = exBoxView.Color.ToAndroid();
				paint.SetMaskFilter(null);
				rectangle = new RectF(0, 0, Width - shadowSize * 2, Height - shadowSize * 2);
				canvas.DrawRoundRect(rectangle, radius, radius, paint);
			}

		}


		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == "Radius")
			{
				Invalidate();
			}
		}

	}
}
