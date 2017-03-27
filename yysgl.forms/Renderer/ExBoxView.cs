using System;
using Xamarin.Forms;

namespace yysgl.forms
{
	//http://www.buildinsider.net/mobile/xamarintips/0034

	public class ExBoxView : BoxView
	{
		// 圆角尺寸
		public static readonly BindableProperty RadiusProperty =
						BindableProperty.Create("Radius", typeof(int), typeof(ExBoxView), 10);
		public int Radius
		{
			get { return (int)GetValue(RadiusProperty); }
			set { SetValue(RadiusProperty, value); }
		}
		public int ShadowSize { get; set; } // 阴影大小

		public ExBoxView()
		{
			Radius = 10;
			ShadowSize = 5;
			WidthRequest = 150;
			HeightRequest = 150;
		}
	}
}
