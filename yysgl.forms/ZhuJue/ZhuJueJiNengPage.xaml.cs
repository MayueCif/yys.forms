

using System.Collections.Generic;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class ZhuJueJiNengPage : ContentPage
	{

		public ZhuJueJiNengPage(ZhuJueModel zhuJue)
		{
			InitializeComponent();

			foreach (var jiNeng in zhuJue.Skills)
			{
				stackLayout.Children.Add(new ZhuJueJiNengItemView()
				{
					Title = jiNeng.Name,
					Image = $"https://yys.res.netease.com/pc/zt/20161027141452/img/skill/{jiNeng.IconID}.png",
					Describe = jiNeng.Describe,
					UpGrade = jiNeng.UpGrade
				});
			}

		}
	}
}
