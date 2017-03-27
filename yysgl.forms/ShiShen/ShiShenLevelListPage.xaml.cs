using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class ShiShenLevelListPage : ContentPage
	{
		public ShiShenLevelListPage()
		{
			InitializeComponent();
			InitDataSource();
			Title = "选择等级";

			BindingContext = this;
		}

		void InitDataSource()
		{

			var levelSourceGroup2 = new LevelSourceGroup()
			{
				Start = "二星",
				Short = "二"
			};
			//2星 20级
			for (int i = 1; i <= 20; i++)
			{
				levelSourceGroup2.Add(new LevelModel()
				{
					Star = 2,
					Level = i
				});
			}
			DataSource.Add(levelSourceGroup2);
			//3星 25级
			var levelSourceGroup3 = new LevelSourceGroup()
			{
				Start = "三星",
				Short = "三"
			};
			for (int i = 21; i <= 25; i++)
			{
				levelSourceGroup3.Add(new LevelModel()
				{
					Star = 3,
					Level = i
				});
			}
			DataSource.Add(levelSourceGroup3);
			//4星 30级
			var levelSourceGroup4 = new LevelSourceGroup()
			{
				Start = "四星",
				Short = "四"
			};
			for (int i = 26; i <= 30; i++)
			{
				levelSourceGroup4.Add(new LevelModel()
				{
					Star = 4,
					Level = i
				});
			}
			DataSource.Add(levelSourceGroup4);
			//5星 35级
			var levelSourceGroup5 = new LevelSourceGroup()
			{
				Start = "五星",
				Short = "五"
			};
			for (int i = 31; i <= 35; i++)
			{
				levelSourceGroup5.Add(new LevelModel()
				{
					Star = 5,
					Level = i
				});
			}
			DataSource.Add(levelSourceGroup5);
			//6星 40级
			var levelSourceGroup6 = new LevelSourceGroup()
			{
				Start = "六星",
				Short = "六"
			};
			for (int i = 36; i <= 40; i++)
			{
				levelSourceGroup6.Add(new LevelModel()
				{
					Star = 6,
					Level = i
				});
			}
			DataSource.Add(levelSourceGroup6);
		}

		public List<LevelSourceGroup> DataSource
		{
			get;
			set;
		} = new List<LevelSourceGroup>();

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Navigation.PopAsync();
			MessagingCenter.Send(this, App.LevelSelectMessageKey, e.SelectedItem as LevelModel);
		}
	}

	public class LevelSourceGroup : List<LevelModel>
	{
		public string Start
		{
			get;
			set;
		}

		public string Short
		{
			get;
			set;
		}

		public static List<LevelSourceGroup> Items
		{
			get;
			set;
		}

	}
}
