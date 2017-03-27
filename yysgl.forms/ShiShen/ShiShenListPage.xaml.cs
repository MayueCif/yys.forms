using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;

namespace yysgl.forms
{
	public partial class ShiShenListPage : ContentPage
	{
		public ShiShenListPage()
		{
			InitializeComponent();
			ShiShenSource = App.Database.GetItems<ShiShenModel>().ToList();
			//处理Image属性
			foreach (var item in ShiShenSource)
			{
				item.Image = $"https://yys.res.netease.com/pc/zt/20161108171335/data/shishen/{item.ID}.png";
			}
			ShiShenGroupSource = new List<ShiShenGroupModel>();
			foreach (var item in ShiShenSource.GroupBy(y => y.Rarity).Select(y => y.Key).OrderByDescending(y => y))
			{
				var shiShenGroup = new ShiShenGroupModel()
				{
					GroupRarity = item
				};
				shiShenGroup.AddRange(ShiShenSource.Where(y => y.Rarity.Equals(item)).OrderBy(y => y.ID));
				ShiShenGroupSource.Add(shiShenGroup);
			}

			BindingContext = this;
		}


		void OnItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e.Item != null)
			{

				var model = e.Item as ShiShenModel;
				Navigation.PushAsync(new ShiShenPage(model.ID));

			}
		}


		public List<ShiShenModel> ShiShenSource
		{
			get;
			set;
		}
		public List<ShiShenGroupModel> ShiShenGroupSource
		{
			get;
			set;
		}
	}
}