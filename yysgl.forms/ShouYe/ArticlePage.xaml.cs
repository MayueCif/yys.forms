using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class ArticlePage : ContentPage
	{
		//当前效果太差，可采用整个webview显示数据，返回数据拼接成整个Html页面
		//https://blog.6ag.cn/1514.html
		//http://www.qingpingshan.com/rjbc/ios/145560.html

		public int ID
		{
			get;
			set;
		}

		public ArticleModel Article
		{
			get;
			set;
		}


		public ArticlePage(int id)
		{
			InitializeComponent();
			ID = id;
			BindingContext = Article;

			ToolbarItems.Add(new ToolbarItem("分享", "share.png", () =>
			{
				DisplayAlert("分享", "分享功能开发中", "确定");
			}));
		}

	}
}
