
[assembly: Xamarin.Forms.Dependency(typeof(yysgl.forms.Droid.BaseUrl))]
namespace yysgl.forms.Droid
{
	public class BaseUrl : IBaseUrl
	{
		public string Get()
		{
			return "file:///android_asset/";
		}
	}
}
