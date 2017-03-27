using System;
using Xamarin.Forms;

namespace yysgl.forms
{
	public class PlaceholderEditor : Editor
	{

		public static readonly BindableProperty PlaceholderProperty =
			BindableProperty.Create("Placeholder", typeof(string), typeof(PlaceholderEditor), default(string));

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create("BorderColor", typeof(Color), typeof(PlaceholderEditor), Color.Transparent);

		public static readonly BindableProperty BorderWidthProperty =
			BindableProperty.Create("BorderWidth", typeof(float), typeof(PlaceholderEditor), default(float));

		public PlaceholderEditor()
		{
		}

		public string Placeholder
		{
			get
			{
				return (string)GetValue(PlaceholderProperty);
			}

			set
			{
				SetValue(PlaceholderProperty, value);
			}
		}


		public Color BorderColor
		{
			get
			{
				return (Color)GetValue(BorderColorProperty);
			}

			set
			{
				SetValue(BorderColorProperty, value);
			}
		}


		public float BorderWidth
		{
			get
			{
				return (float)GetValue(BorderWidthProperty);
			}

			set
			{
				SetValue(BorderWidthProperty, value);
			}
		}
	}
}
