using System;
using System.Collections.Generic;
using Plugin.Media;
using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class FeedbackPage : ContentPage
	{
		async void AddImageTapped(object sender, System.EventArgs e)
		{
			await CrossMedia.Current.Initialize();


			if (!CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", ":( No Photo Supported.", "OK");
				return;
			}

			var file = await CrossMedia.Current.PickPhotoAsync();

			if (file == null)
				return;

			image.Source = ImageSource.FromStream(() =>
			{
				var stream = file.GetStream();
				file.Dispose();
				return stream;
			});

		}

		void SubmitActivated(object sender, System.EventArgs e)
		{

		}

		public FeedbackPage()
		{
			InitializeComponent();
		}
	}
}
