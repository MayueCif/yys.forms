using System;
using Xamarin.Forms;

namespace yysgl.forms
{
	public class MyueLabel : Label
	{
		public static readonly BindableProperty IsMarqueeProperty =
		BindableProperty.Create("IsMarquee", typeof(bool), typeof(MyueLabel), false);

		public bool IsMarquee
		{
			get
			{
				return (bool)GetValue(IsMarqueeProperty);
			}
			set
			{
				SetValue(IsMarqueeProperty, value);
			}
		}
	}
}
