using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class MorePage : ContentPage
	{

		public bool IsDarkTheme
		{
			get;
			set;
		} = Application.Current.Properties.ContainsKey("IsDarkTheme") && (bool)Application.Current.Properties["IsDarkTheme"];

		void StyleOnChanged(object sender, ToggledEventArgs e)
		{
			//Application.Current.Properties["IsDarkTheme"] = e.Value;
			////夜间模式
			//if (e.Value)
			//{
			//	Application.Current.Resources["backgroundColor"] = Color.FromHex("33302E");
			//	Application.Current.Resources["textColor"] = Color.White;
			//}
			//else {
			//	Application.Current.Resources["backgroundColor"] = Color.White;
			//	Application.Current.Resources["textColor"] = Color.Black;
			//}
			DisplayAlert("再等等", "我也想有这个功能", "确定");
			//https://kingideayou.github.io/2016/03/07/appcompat_23.2_day_night/?utm_source=tuicool&utm_medium=referral
			//https://developer.xamarin.com/guides/xamarin-forms/themes/
		}

		public MorePage()
		{
			InitializeComponent();

			OpenMusic = new Command(() =>
			{
				Navigation.PushAsync(new MusicListPage());
			});

			OpenHeadPortrait = new Command(() =>
			{
				Navigation.PushAsync(new HeadPortraitPage());
			});

			OpenFeedback = new Command(() =>
			{
				Navigation.PushAsync(new FeedbackPage());
			});

			AppScore = new Command(() =>
			{
				DependencyService.Get<IAppScore>().StartAppScore();
			});

			OpenShare = new Command(() =>
			{
				DependencyService.Get<IShare>().Open("阴阳师盒子", "https://itunes.apple.com/cn/app/id1208535392",
													 Device.OnPlatform("launch.png", "icon.png", ""));
			});

			OpenGameCalendar = new Command(() =>
			{
				Navigation.PushAsync(new GameCalendarPage());
			});


			OpenRewardSearch = new Command(() =>
			{
				Navigation.PushAsync(new RewardSearchPage());
			});

			BindingContext = this;
		}

		public ICommand OpenMusic
		{
			get;
			set;
		}

		public ICommand OpenGameCalendar
		{
			get;
			set;
		}

		public ICommand OpenHeadPortrait
		{
			get;
			set;
		}

		public ICommand OpenFeedback
		{
			get;
			set;
		}

		public ICommand AppScore
		{
			get;
			set;
		}

		public ICommand OpenShare
		{
			get;
			set;
		}

		public ICommand OpenRewardSearch
		{
			get;
			set;
		}

		public ICommand OpenZhiBo
		{
			get;
			set;
		}

	}
}
