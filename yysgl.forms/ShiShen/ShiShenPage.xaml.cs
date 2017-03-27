using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
namespace yysgl.forms
{
	public partial class ShiShenPage : ContentPage
	{
		public string BigImageUrl
		{
			get;
			set;
		}

		public ShiShenParameterModel BeforeAwake
		{
			get;
			set;
		}

		public ShiShenParameterModel AfterAwake
		{
			get;
			set;
		} = new ShiShenParameterModel();

		public ShiShenModel ShiShen
		{
			get;
			set;
		}

		public List<ShiShenJiNengModel> JiNengList
		{
			get;
			set;
		}

		public string dubUrl
		{
			get;
			set;
		}

		IAudioPlayer audioPlayer;

		public ShiShenPage(int shiShenID)
		{
			InitializeComponent();

			audioPlayer = DependencyService.Get<IAudioPlayer>();
			//播放结束
			audioPlayer.Completed += (sender, e) =>
			{
				button.Image = new FileImageSource()
				{
					File = Device.OnPlatform("play.png", "play.png", "play.png")
				};
			};

			Title = "式神详情";
			ShiShen = App.Database.Query<ShiShenModel>("select * from [ShiShen] where ID = ? ", shiShenID).FirstOrDefault();
			ShiShen.ChineseBiography = ShiShen.ChineseBiography.Replace("。,", "。" + Environment.NewLine)
									.Replace("？,", "？" + Environment.NewLine).Replace("！,", "！" + Environment.NewLine);
			if (ShiShen != null)
			{
				BigImageUrl = $"https://yys.res.netease.com/pc/zt/20161108171335/data/shishen_big/{ShiShen.ID}.png";
				dubUrl = $"https://yys.res.netease.com/pc/zt/20161108171335/data/mp3/{ShiShen.ID}.mp3";
				BeforeAwake = App.Database.Query<ShiShenParameterModel>("select * from [ShiShenParameter] where ID = ?", ShiShen.BeforeAwakeID).FirstOrDefault();
				AfterAwake = App.Database.Query<ShiShenParameterModel>("select * from [ShiShenParameter] where ID = ?", ShiShen.AfterAwakeID).FirstOrDefault();

				if (BeforeAwake != null)
				{
					BeforeAwake.HeadImage = $"https://yys.res.netease.com/pc/zt/20161108171335/data/before_awake/{ShiShen.ID}.jpg ";
				}

				if (AfterAwake != null)
				{
					AfterAwake.HeadImage = $"https://yys.res.netease.com/pc/zt/20161108171335/data/after_awake/{ShiShen.ID}.jpg ";
				}

				JiNengList = App.Database.Query<ShiShenJiNengModel>("select * from [ShiShenJiNeng] where ShiShenID = ?", ShiShen.ID)
								.OrderBy(j => j.IconID).ToList();

				foreach (var jiNeng in JiNengList)
				{
					jiNeng.UpgradeEffect = jiNeng.UpgradeEffect.Replace(",", Environment.NewLine);
					jiNeng.Icon = $"https://yys.res.netease.com/pc/zt/20161108171335/data/skill/{jiNeng.IconID}.png";
				}
				var childrenCount = jiNengStackLayout.Children.Count;
				//处理部分式神为1个或两个技能的问题
				for (int i = 1; i <= childrenCount - JiNengList.Count; i++)
				{
					jiNengStackLayout.Children.RemoveAt(childrenCount - i);
				}

			}

			BindingContext = this;
		}
		int CurrentIndex = 0;
		int HeaderIndex = 1;
		int ContentIndex = 3;
		int ColumnCount = 4;
		void OnHeaderTapped(object sender, EventArgs e)
		{
			var element = (sender as Label);
			var columnIndex = Grid.GetColumn(element);
			//var rowIndex = Grid.GetRow(element);
			if (columnIndex == CurrentIndex)
			{
				return;
			}
			//设置当前索引值
			CurrentIndex = columnIndex;
			//设置指示器位置
			Grid.SetColumn(indicator, columnIndex);
			//循环处理 
			for (int i = 0; i < ColumnCount; i++)
			{
				//grid.Children.Where(c => Grid.GetRow(c) == row && Grid.GetColumn(c) == 1);
				var headerElement = grid.Children.Where(c => Grid.GetRow(c) == HeaderIndex && Grid.GetColumn(c) == i).FirstOrDefault();
				if (headerElement is Label)
				{
					(headerElement as Label).TextColor = Color.Black;
				}
			}
			//设置选中色
			element.TextColor = Color.Blue;
			//内容都放在0，2的单元中 否则显示出现问题
			var contentElements = grid.Children.Where(c => Grid.GetRow(c) == ContentIndex && Grid.GetColumn(c) == 0).ToList();
			//处理显示内容 
			for (int i = 0; i < contentElements.Count; i++)
			{
				contentElements[i].IsVisible = CurrentIndex == i;
			}
		}

		void OnQueryPageClicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new ShiShenAttributeQueryPage(ShiShen.ID));
		}

		void OnClicked(object sender, System.EventArgs e)
		{
			if (audioPlayer.GetPalyState())
			{
				//暂停操作
				audioPlayer.Pause();
				button.Image = new FileImageSource()
				{
					File = Device.OnPlatform<string>("play.png", "play.png", "play.png")
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
					audioPlayer.PlayNet(dubUrl);
				}
				button.Image = new FileImageSource()
				{
					File = Device.OnPlatform<string>("pause.png", "pause.png", "pause.png")
				};
			}
		}


		async void OnLongPress(object sender, EventArgs e)
		{
			var action = await DisplayActionSheet("图片操作", "取消", null, "保存图片");
			switch (action)
			{
				case "保存图片":
					break;
				default:
					break;
			}
		}


		protected override void OnDisappearing()
		{
			audioPlayer.Stop();

		}
	}
}