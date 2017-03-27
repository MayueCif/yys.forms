using System;
using Xamarin.Forms;

namespace yysgl.forms
{
	public interface IShare
	{
		void Open(string title, string url = null, string imageName = null);
	}
}
