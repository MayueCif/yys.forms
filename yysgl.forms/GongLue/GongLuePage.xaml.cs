using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class GongLuePage : ContentPage
	{
		public GongLuePage()
		{
			InitializeComponent();
			OpenGongLueList = new Command((arg) =>
			{
				//title 和url 由 || 分割。
				var argArr = arg.ToString().Split('|');
				Navigation.PushAsync(new GongLueListPage(argArr[0], argArr[1]));
			});
			BindingContext = this;
		}

		public ICommand OpenGongLueList
		{
			get;
			set;
		}
	}
}
