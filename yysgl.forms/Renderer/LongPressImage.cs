
using System;
using Xamarin.Forms;

namespace yysgl.forms
{
	public class LongPressImage : Image
	{
		public event EventHandler LongPress;

		public void OnLongPress()
		{
			if (LongPress != null)
			{
				LongPress(this, new EventArgs());
			}
		}
	}
}
