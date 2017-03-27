
using Android.Content;
using Android.Net;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.Droid.AppScore))]
namespace yysgl.forms.Droid
{
	public class AppScore : IAppScore
	{
		public void StartAppScore()
		{
			var uri = Uri.Parse("market://details?id=" + Forms.Context.PackageName);
			var intent = new Intent(Intent.ActionView, uri);

			intent.AddFlags(ActivityFlags.NewTask);

			var componentName = intent.ResolveActivity(Forms.Context.PackageManager);
			if (componentName != null)
			{
				Forms.Context.StartActivity(intent);
			}
			else
			{
				Toast.MakeText(Forms.Context, "没有检测到应用商店", ToastLength.Long).Show();
			}


		}
	}
}
