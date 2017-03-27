using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace yysgl.forms
{
	public partial class YuHunListPage : ContentPage
	{

		public YuHunListPage()
		{
			InitializeComponent();

			YuHunSource = App.Database.GetItems<YuHunModel>().ToList();

			foreach (var yuHun in YuHunSource)
			{
				//yysgl.forms.Resource.XXXXX.png
				yuHun.Image = $"yysgl.forms.Resource.{yuHun.Image}";
			}

			YuHunGroupSource = new List<YuHunGroupModel>();
			foreach (var item in YuHunSource.GroupBy(y => y.Type).Select(y => y.Key).OrderBy(y => y))
			{
				var yuHunGroup = new YuHunGroupModel()
				{
					GroupType = item
				};
				yuHunGroup.AddRange(YuHunSource.Where(y => y.Type.Equals(item)).OrderBy(y => y.Name));
				YuHunGroupSource.Add(yuHunGroup);
			}

			BindingContext = this;
		}


		void ListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				(sender as ListView).SelectedItem = null;
			}

		}

		public List<YuHunModel> YuHunSource
		{
			get;
			set;
		}

		public List<YuHunGroupModel> YuHunGroupSource
		{
			get;
			set;
		}

	}
}
