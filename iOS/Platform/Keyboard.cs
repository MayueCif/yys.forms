
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(yysgl.forms.iOS.Keyboard))]
namespace yysgl.forms.iOS
{
	public class Keyboard : IKeyboard
	{

		public void HideKeyboard()
		{
			UIApplication.SharedApplication.KeyWindow.EndEditing(true);
		}
	}
}
