using System;
using System.ComponentModel;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(yysgl.forms.PlaceholderEditor), typeof(yysgl.forms.Droid.PlaceholderEditorRenderer))]
namespace yysgl.forms.Droid
{
	public class PlaceholderEditorRenderer : EditorRenderer
	{

		protected override void OnElementChanged(
			ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var element = e.NewElement as PlaceholderEditor;
				this.Control.Hint = element.Placeholder;

				Control.Background.SetColorFilter(element.BorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
			}

		}

		protected override void OnElementPropertyChanged(
			object sender,
			PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == PlaceholderEditor.PlaceholderProperty.PropertyName)
			{
				var element = this.Element as PlaceholderEditor;
				this.Control.Hint = element.Placeholder;
			}
		}
	}
}
