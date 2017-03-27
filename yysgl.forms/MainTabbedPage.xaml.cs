using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class MainTabbedPage : TabbedPage
	{
		void OnCurrentPageChanged(object sender, EventArgs e)
		{
			if (CurrentPage is ArticleListPage)
			{
				Title = "资讯";
			}
			else if (CurrentPage is ShiShenListPage)
			{
				Title = "式神";
			}
			else if (CurrentPage is YuHunListPage)
			{
				Title = "御魂";
			}
			else if (CurrentPage is MorePage)
			{
				Title = "更多";
			}
			else if (CurrentPage is GongLuePage)
			{
				Title = "攻略";
			}
			else if (CurrentPage is ZhuJuePage)
			{
				Title = "主角录";
			}
			else
			{
				Title = "未知标题";
			}

			MessagingCenter.Send(this, "CurrentPageChanged");

		}

		public MainTabbedPage()
		{
			InitializeComponent();
		}
	}
}
