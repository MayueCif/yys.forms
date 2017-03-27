using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace yysgl.forms
{
	public partial class ZhuJueJianJiePage : ContentPage
	{

		IAudioPlayer audioPlayer;
		string audioUrl = "";

		public ZhuJueJianJiePage(ZhuJueModel zhuJue)
		{
			InitializeComponent();

			audioPlayer = DependencyService.Get<IAudioPlayer>();

			for (int i = 0; i < zhuJue.Summary.Count; i++)
			{
				stackLayout.Children.Insert(i, new Label()
				{
					Text = zhuJue.Summary[i],
					Margin = new Thickness(16)
				});
			}

			button.Text = $"CV({zhuJue.CV})";
			audioUrl = $"https://nie.res.netease.com/yys/2016/mp3/{zhuJue.ID}.mp3";

		}

		void OnClicked(object sender, System.EventArgs e)
		{
			if (audioPlayer.GetPalyState())
			{
				//暂停操作
				audioPlayer.Pause();
				button.Image = new FileImageSource()
				{
					File = Device.OnPlatform("play.png", "play.png", "play.png")
				};
			}
			else
			{
				//播放操作
				if (audioPlayer.GetCurrentDuration() > 0)
				{
					audioPlayer.Start();
				}
				else
				{
					audioPlayer.PlayNet(audioUrl);
				}
				button.Image = new FileImageSource()
				{
					File = Device.OnPlatform("pause.png", "pause.png", "pause.png")
				};
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			if (audioPlayer != null)
			{
				audioPlayer.Stop();
				audioPlayer = null;
			}
		}
	}
}
