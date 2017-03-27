

using System.IO;
using Xamarin.Forms;


namespace yysgl.forms
{
	public partial class GameCalendarPage : ContentPage
	{
		public GameCalendarPage()
		{
			InitializeComponent();
			Title = "游戏日历";
			webView.Source = new UrlWebViewSource()
			{
				Url = Path.Combine(DependencyService.Get<IBaseUrl>().Get(), "calendar.html")
			};

		}
	}
}
