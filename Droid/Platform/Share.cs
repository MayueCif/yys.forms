
using Android.App;
using Android.Content;
using Android.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.Droid.Share))]
namespace yysgl.forms.Droid
{
	public class Share : IShare
	{
		public void Open(string title, string url = null, string imageName = null)
		{
			var shareIntent = new Intent();
			shareIntent.SetAction(Intent.ActionSend);
			shareIntent.PutExtra(Intent.ExtraText, url);
			shareIntent.PutExtra(Intent.ExtraSubject, title);

			var resourceId = Forms.Context.Resources.GetIdentifier(imageName.Split('.')[0], "drawable", Forms.Context.PackageName);
			//var _resourceId = (int)typeof(Resource.Drawable).GetField("icon").GetValue(null);
			//var imageUri = Uri.Parse("android.resource://" + Forms.Context.PackageName + "/drawable/" + resourceId);
			//shareIntent.PutExtra(Intent.ExtraStream, imageUri);

			shareIntent.SetType("text/plain");
			//shareIntent.SetType("image/*");
			//shareIntent.AddFlags(ActivityFlags.ClearWhenTaskReset);
			shareIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
			Forms.Context.StartActivity(Intent.CreateChooser(shareIntent, "分享到"));

		}
	}
}
