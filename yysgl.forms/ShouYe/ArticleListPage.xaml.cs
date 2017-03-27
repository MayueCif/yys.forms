using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace yysgl.forms
{
	public partial class ArticleListPage : ContentPage
	{
		async void ListItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{

			if (e.SelectedItem != null)
			{

				var model = e.SelectedItem as BaseArticleModel;
				await Navigation.PushAsync(new ArticlePage(model.ID));
				//取消选中状态
				(sender as ListView).SelectedItem = null;
			}

		}

		public ArticleListPage()
		{

			InitializeComponent();



			ListViewSource = new ObservableCollection<BaseArticleModel> {
				new BaseArticleModel(){
					ID=1,
					Title="ListView Model Title 1,long title ",
					Date="2016-12-22",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=2,
					Title="ListView Model Title 2,Title",
					Date="2016-6-22",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=3,
					Title="ListView Model Title 3 Long long title",
					Date="2016-12-15",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=4,
					Title="ListView Model Title 4",
					Date="2016-12-17",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=5,
					Title="ListView Model Title 5,这个标题真的很长啊，这个标题真的很长啊",
					Date="2016-12-18",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=6,
					Title="ListView Model Title 6",
					Date="2016-12-22",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=6,
					Title="ListView Model Title 7",
					Date="2016-11-22",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=6,
					Title="ListView Model Title 8",
					Date="2016-12-24",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				},
				new BaseArticleModel(){
					ID=6,
					Title="ListView Model Title 9",
					Date="2016-12-25",
					Column="网易官网",
					Image="http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png"
				}
			};


			CarouselViewSource = new ObservableCollection<BaseArticleModel>
			{
				new BaseArticleModel
				{
					ID=1,
					Image = "http://p1.bqimg.com/1949/3a04a827484110a2.png",
					Title = "Woodland Park Zoo"
				},
				new BaseArticleModel
				{
					ID=2,
					Image = "http://p1.bqimg.com/1949/3a04a827484110a2.png",
					Title = "Cleveland Zoo"
				},
				new BaseArticleModel
				{
					ID=3,
					Image = "http://p1.bqimg.com/1949/3a04a827484110a2.png",
					Title = "Phoenix Zoo"
				}
			};


			MessagingCenter.Subscribe<MainTabbedPage>(this, "CurrentPageChanged", (sender) =>
			{

			});

			BindingContext = this;

		}


		public ObservableCollection<BaseArticleModel> ListViewSource
		{
			get;
			set;
		} = new ObservableCollection<BaseArticleModel>();

		public ObservableCollection<BaseArticleModel> CarouselViewSource
		{
			get;
			set;
		} = new ObservableCollection<BaseArticleModel>();



	}

	public class UriImageConvert : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return new UriImageSource()
			{
				Uri = new Uri((string)value)
			};
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
