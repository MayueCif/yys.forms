
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using DLToolkit.Forms.Controls;
using FFImageLoading.Forms.Droid;

namespace yysgl.forms.Droid
{
	[Activity(Label = "阴阳师盒子", MainLauncher = false, Icon = "@drawable/icon", Theme = "@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait,
			  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			CarouselViewRenderer.Init();
			FlowListView.Init();
			CachedImageRenderer.Init();
			UserDialogs.Init(this);

			//AndroidAppLinks.Init(this);

			MobileAds.Initialize(ApplicationContext, "ca-app-pub-2079580879894926~9878575093");

			FileAccessHelper.GetLocalFilePath("Data.sqlite");

			LoadApplication(new App());

			//var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
			//x = typeof(Xamarin.Forms.Themes.LightThemeResources);
			//x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
		}
	}
}
