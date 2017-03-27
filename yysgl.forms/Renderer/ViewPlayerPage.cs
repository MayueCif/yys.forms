using System;

using Xamarin.Forms;

namespace yysgl.forms
{
	public class ViewPlayerPage : ContentPage
	{
		/// <summary>
		/// 视频地址
		/// </summary>
		/// <value>The URL.</value>
		public string Url
		{
			get;
			set;
		}
		public ViewPlayerPage(string url)
		{
			Url = url;
		}
	}
}

