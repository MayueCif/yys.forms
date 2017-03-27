
using Android.App;
using Android.OS;

namespace yysgl.forms.Droid
{
	[Activity(MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			StartActivity(typeof(MainActivity));
		}
	}
}
