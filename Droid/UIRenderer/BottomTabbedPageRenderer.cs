using System;
using Android.Support.Design.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(yysgl.forms.Droid.BottomTabbedPageRenderer))]
namespace yysgl.forms.Droid
{
	//https://asyncawait.wordpress.com/2016/06/16/bottom-menu-for-xamarin-forms-android/
	//http://www.cnblogs.com/xling/p/5129752.html

	public class BottomTabbedPageRenderer : TabbedPageRenderer
	{

		private Android.Views.View formViewPager = null;
		private TabLayout tabLayout = null;

		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
		{
			base.OnElementChanged(e);

			this.formViewPager = this.GetChildAt(0);
			this.tabLayout = (TabLayout)this.GetChildAt(1);

			this.UpdateLayout();
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);

			// update layout , let tab on the bottom of the page
			// formViewPager upon tab.
			var w = r - 1;
			var h = b - t;
			if (w > 0 && h > 0)
			{
				int ypos = Math.Min(h, Math.Max(this.tabLayout.MeasuredHeight, this.tabLayout.MinimumHeight));
				this.formViewPager.Layout(0, -ypos, r, b - ypos);
				this.tabLayout.Layout(l, h - ypos, r, b);
			}
		}

	}


}
