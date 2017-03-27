using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class App : Application
	{
		public static readonly string LevelSelectMessageKey = "LevelSelect";

		private readonly string DatabaseName = "Data.sqlite";
		public static Database Database
		{
			get;
			set;
		}

		public App()
		{
			InitializeComponent();

			//Load the assembly
			Xamarin.Forms.DataGrid.DataGridComponent.Init();

			//初始化数据库对象
			Database = new Database(DatabaseName);
			//Database.CreateTable

			var navigationPage = new NavigationPage(new MainTabbedPage());
			//navigationPage.SetDynamicResource(NavigationPage.BarTextColorProperty, "textColor");
			//navigationPage.SetDynamicResource(NavigationPage.BarBackgroundColorProperty, "backgroundColor");
			MainPage = navigationPage;


			//监听 3D Touch 
			MessagingCenter.Subscribe<App>(this, "OpenQueryPage", (sender) =>
			 {
				 // set initial state
				 MainPage.Navigation.PopToRootAsync();

				 // display screen
				 MainPage.Navigation.PushAsync(new RewardSearchPage());
			 });
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
